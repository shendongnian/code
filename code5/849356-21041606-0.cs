    public ActionResult Index()
        {
            ViewBag.DisplayTable = GetKeyValueDisplayContent(@"YourFilePath.Txt");
            return View();
        }
        private string GetKeyValueDisplayContent(string fileToRead)
        {
            // 01 Get Data
            string DataToProcess = GetDataToProcess(fileToRead);
            // 02 Cleaning Data (replacing all tabs white space new line and everything)
            DataToProcess = CleanDataToProcess(DataToProcess);
            
            // 03 Retrieve Array from Data format
            string[] output = GetDataInArray(DataToProcess);
            // 04 Displaying Result
            string DrawTable = GetDisplayHTML(output);
            return DrawTable;
        }
        private string GetDataToProcess(string fileToRead)
        {
            StreamReader reader = new StreamReader(fileToRead);
            string data = reader.ReadToEnd();
            reader.Close();
            return data;
        }
        private string CleanDataToProcess(string dataToProcess)
        {
            return Regex.Replace(dataToProcess, @"\s", "");
        }
        private string[] GetDataInArray(string dataToProcess)
        {
            string pattern = @"({next})|({KeyValuePair}{)|(}{next})";
            string[] output = Regex.Split(dataToProcess, pattern);
            return output;
        }
        private string GetDisplayHTML(string[] output)
        {
            int length = output.Length;
            int count = 0;
            StringBuilder OutputToPrint = new StringBuilder();
            foreach (string one in output)
            {
                if (one == "{KeyValuePair}{")
                {
                    count++;
                    if (count >= 2)
                    {
                        OutputToPrint.Append("<td><table border = \"1\">");
                    }
                    else
                    {
                        OutputToPrint.Append("<table border = \"1\">");
                    }
                }
                else if (one.Contains("=") == true)
                {
                    string[] keyVal = Regex.Split(one, @"=");
                    OutputToPrint.Append("<tr>");
                    foreach (string val in keyVal)
                    {
                        if (val != "")
                        {
                            OutputToPrint.Append("<td>");
                            OutputToPrint.Append(WebUtility.HtmlEncode(val));
                            OutputToPrint.Append("</td>");
                        }
                    }
                }
                else if (one.Equals("{next}"))
                {
                    OutputToPrint.Append("</tr>");
                }
                else if (one.Contains("}{next}") == true)
                {
                    OutputToPrint.Append("</table></td>");
                }
                else if (one == "}")
                {
                    OutputToPrint.Append("</table>");
                }
                else { }
            }
            return OutputToPrint.ToString();
        }
