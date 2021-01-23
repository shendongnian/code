        static void Main(string[] args)
        {
            string textFile = @"08/12/2014 00:59:41   Ok
    08/12/2014 01:05:01   Ok
    08/12/2014 01:10:01   Ok
    08/12/2014 01:15:02   Ok
    08/12/2014 01:20:01   Ok
    08/12/2014 01:25:01   Ok
    08/12/2014 01:30:01   Ok
    08/12/2014 01:35:01   Ok
    08/12/2014 01:40:01   Ok
    08/12/2014 01:45:01   Ok
    08/12/2014 01:50:01   Ok
    08/12/2014 01:55:01   Ok
    08/12/2014 02:00:01   Ok";
            textFile = textFile.Replace("\r", "");
            textFile = textFile.Replace("Ok", "");
            string[] lines = textFile.Split('\n');
           
            List<DateTime> newList = new List<DateTime>();
            for (int i = 0; i < lines.Length; i ++)
            {
                if(i == lines.Length - 1)
                   break;
  
                DateTime date1 = Convert.ToDateTime(lines[i]);
                DateTime date2 = Convert.ToDateTime(lines[i+1]);
                if(Math.Abs((date1 - date2).TotalMinutes) >= 5)
                {
                    //I suppose that the second value is always bigger than the first
                    newList.Add(date2);
                }
            }
            TextWriter tw = new StreamWriter(@"C:\test1.txt");
            foreach (DateTime s in newList)
                tw.WriteLine(s);
            tw.Close();
        }
