    [ReflectorType("execWithOutput")]
    class ExecutableTestTask:ExecutableTask
    {
        [ReflectorProperty("OutputFilePath", Required = false)]
        public string OutputFilePath { get; set; }
        protected override bool Execute(ThoughtWorks.CruiseControl.Core.IIntegrationResult result)
        {
            bool rez = base.Execute(result);
            if (!string.IsNullOrEmpty(OutputFilePath))
            {
                using (FileStream fs = new FileStream(OutputFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        var lastIndex = result.TaskResults.Count-1;
                        // read output from last executed task
                        var output = ((ProcessTaskResult)result.TaskResults[lastIndex]).Data;
                        string parsedOutput = readMessagesFromXml(output);
                        sw.Write(parsedOutput);
                    }
                }
            }
            return rez;
        }
        // parse xml
        private string readMessagesFromXml(string xml)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                // wrap output to into single root node
                var xmlWithRootNode = string.Format("<report>{0}</report>", xml);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlWithRootNode);
                var nodes = doc.SelectNodes("//report/buildresults/message");
                if (nodes.Count > 0)
                {
                    foreach (XmlNode node in nodes)
                    {
                        sb.AppendLine("<div>" + node.InnerText + "</div>");
                    }
                }
                else
                {
                    sb.AppendLine("Xml output does not contain valid data or there are no messages");
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("Exception during parsing XML task output. "+ex.ToString());
            }
            return sb.ToString();
        }
