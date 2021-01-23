    using System;
    
    public class StreamMessageInspector : IDispatchMessageInspector {
    	#region Implementation of IDispatchMessageInspector
    
    	public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext) {
    		if (request.IsEmpty) {
    			return null;
    		}
    
    		const string action = "<FullNameOfOperation>";
    
    		// Only process action requests for now
    		var operationName = request.Properties["HttpOperationName"] as string;
    		if (operationName != action) {
    			return null;
    		}
    
    		// Check that the content type of the request is set to a form post, otherwise do no more processing
    		var prop = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
    		var contentType = prop.Headers["Content-Type"];
    		if (contentType != "application/x-www-form-urlencoded") {
    			return null;
    		}
    
    		///////////////////////////////////////
    		// Build the body from the form values
    		string body;
    
    		// Retrieve the base64 encrypted message body
    		using (var ms = new MemoryStream()) {
    			using (var xw = XmlWriter.Create(ms)) {
    				request.WriteBody(xw);
    				xw.Flush();
    				body = Encoding.UTF8.GetString(ms.ToArray());
    			}
    		}
    
    		// Trim any characters at the beginning of the string, if they're not a <
    		body = TrimExtended(body);
    
    		// Grab base64 binary data from <Binary> XML node
    		var doc = XDocument.Parse(body);
    		if (doc.Root == null) {
    			// Unable to parse body
    			return null;
    		}
    
    		var node = doc.Root.Elements("Binary").FirstOrDefault();
    		if (node == null) {
    			// No "Binary" element
    			return null;
    		}
    
    		// Decrypt the XML element value into a string
    		var bodyBytes = Convert.FromBase64String(node.Value);
    		var bodyDecoded = Encoding.UTF8.GetString(bodyBytes);
    
    		// Deserialize the form request into the correct data contract
    		var qss = new QueryStringSerializer();
    		var newContract = qss.Deserialize<MyServiceContract>(bodyDecoded);
    
    		// Form the new message and set it
    		var newMessage = Message.CreateMessage(OperationContext.Current.IncomingMessageVersion, action, newContract);
    		request = newMessage;
    		return null;
    	}
    
    	public void BeforeSendReply(ref Message reply, object correlationState) {
    	}
    
    	#endregion
    
    	/// <summary>
    	///     Trims any random characters from the start of the string. I would say this is a BOM, but it doesn't seem to be.
    	/// </summary>
    	/// <param name="s"></param>
    	/// <returns></returns>
    	private string TrimExtended(string s) {
    		while (true) {
    			if (s.StartsWith("<")) {
    				// Nothing to do, return the string
    				return s;
    			}
    
    			// Replace the first character of the string
    			s = s.Substring(1);
    			if (!s.StartsWith("<")) {
    				continue;
    			}
    			return s;
    		}
    	}
    }
