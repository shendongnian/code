    /// <summary>
    /// This method is called when this script task executes in the control flow.
    /// Before returning from this method, set the value of Dts.TaskResult to indicate success or
    /// failure.
    /// </summary>
		public void Main()
		{
            if (Dts.Variables.Contains("yourReqVar") == true)
            {
                try
                {
                    object nativeObject = Dts.Connections["YourWebservice"].AcquireConnection(null);
                    HttpClientConnection conn = new HttpClientConnection(nativeObject);
                    YourService ws = new YourService(conn.ServerURL);
                    GetUpdatedRequest req = new GetUpdatedRequest();
                    req.username = conn.ServerUserName;
                    req.password = "A123232";
                    req.dateRange = new dateRange();
                    req.dateRange.from = DateTime.Now.AddDays((dayIncrement * -1));
                    req.dateRange.to = DateTime.Now;
                    req.dateRange.fromSpecified = true;
                    req.dateRange.toSpecified = true;
                    GetUpdatedResponse response = ws.GetUpdated(req);
                    System.Xml.Serialization.XmlSerializer x
                      = new System.Xml.Serialization.XmlSerializer(response.GetType());
                    StringWriterWithEncoding responseToXml
                      = new StringWriterWithEncoding(new StringBuilder(), Encoding.UTF8);
                    x.Serialize(responseToXml, response);
                    Dts.Variables["User::GetUpdated"].Value = responseToXml.ToString();
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
                catch (Exception) {
                    Dts.Events.FireWarning(0, "Skip", "Failed to retrieve updated.", String.Empty, 0);
                    Dts.TaskResult = (int)ScriptResults.Success;
                }
            }
            else
            {
                Dts.TaskResult = (int)ScriptResults.Failure;
            }
		}
