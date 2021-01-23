     string myString = "C125:AAAAA|C12:22222|C16542:D1|ABCD:1234A|C6:12AAA";
            StringBuilder result=new StringBuilder();
            List<string> resulttemp = myString.Split('|').ToList();
            foreach (string[] temp in from v in resulttemp where v.StartsWith("C") select v.Split(':'))
            {
                result.Append("string ");
                result.Append(temp[0]);
                result.Append("=");
                result.Append("\"");
                result.Append(temp[1]);
                result.Append("\"");
                result.Append(";");
                result.Append("\n");
            }
