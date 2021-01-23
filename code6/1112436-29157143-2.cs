	/// <summary>
	/// Summary description for OutboundResultUrl
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class OutboundResultUrl : System.Web.Services.WebService
	{
		[WebMethod]
		public string PlumOutboundCallback()
		{
			bool heartbeat = string.IsNullOrEmpty(HttpContext.Current.Request.Form["phone_number"]); //Plum implements a heartbeat and checks that this 'result_url' is working. A 'phone_number' has to exist in order for me to process the data FOR a call (duh) so I check to see if it is null or empty
			if (!heartbeat)
			{
				//BusinessLayer.OutboundCallback model = new BusinessLayer.OutboundCallback { phone_number = HttpContext.Current.Request.Form["phone_number"], message_reference = HttpContext.Current.Request.Form["message_reference"], call_id = Convert.ToInt32(HttpContext.Current.Request.Form["call_id"]), result = HttpContext.Current.Request.Form["result"], callee_type = HttpContext.Current.Request.Form["callee_type"], attempts = Convert.ToInt32(HttpContext.Current.Request.Form["attempts"]), last_attempt_timestamp = HttpContext.Current.Request.Form["last_attempt_timestamp"], duration = Convert.ToInt32(HttpContext.Current.Request.Form["duration"]) }; //if you're into this sort of thing
				BusinessLayer.OutboundCallback model = new BusinessLayer.OutboundCallback();
				model.phone_number = HttpContext.Current.Request.Form["phone_number"];
				model.message_reference = HttpContext.Current.Request.Form["message_reference"];
				model.call_id = Convert.ToInt32(HttpContext.Current.Request.Form["call_id"]);
				model.result = HttpContext.Current.Request.Form["result"];
				model.callee_type = HttpContext.Current.Request.Form["callee_type"];
				model.attempts = Convert.ToInt32(HttpContext.Current.Request.Form["attempts"]);
				model.last_attempt_timestamp = HttpContext.Current.Request.Form["last_attempt_timestamp"];
				model.duration = Convert.ToInt32(HttpContext.Current.Request.Form["duration"]);
				string stringResultData = string.Format("Collecting parameters posted into here. <br />Phone Number = {0}, <br />Message Reference = {1}, <br />Call ID = {2}, <br />Result = {3}, <br />Callee Type = {4}, <br />Attempts = {5}, <br />Last Attempt Timestamp = {6}, <br />Duration = {7}",
										model.phone_number, model.message_reference, model.callee_type, model.result, model.callee_type, model.attempts, model.last_attempt_timestamp, model.duration); //this is for debugging/testing purposes
				try
				{
					// Whatever you want to do with this data! Send it in an email, Save it to the database, etc.
				}
				catch (Exception error)
				{
					Console.WriteLine("Error: " + error);
				}
			}
			return "Plum Outbound API has posted back to this 'result_url' successfully.";
		}
	}
	
