            //Dummy values for testing
            List<string> lines = new List<string>();
            lines.Add("Hello from text");
            lines.Add("Wed, 29 Jan 2014 06:01:56 +0200");
            lines.Add("Hello from text1");
            lines.Add("Wed, 29 Jan 2014 06:01:56 +0200");
            StringBuilder strToAddToList = new StringBuilder();
            for (int i = 0; i < lines.Count; i++)
            {
                if (i % 2 == 0)
                {
                    strToAddToList.Append(lines[i]);
                    continue;
                }
                if (i % 2 != 0)
                {
                    strToAddToList.Append(" ");
                    strToAddToList.Append(lines[i]);
                    Console.WriteLine(strToAddToList);//You can replace this with your ListView.Add code
                    strToAddToList.Clear();
                }
            }
