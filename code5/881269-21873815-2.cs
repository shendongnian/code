            List<string> lines = new List<string>();
            List<String> orderList = new List<String>();
            String line;
            int count=0;
            using (StreamReader reader = new StreamReader("c:\\Bethlehem-Deployment.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                    count++;
                }
            }
            int loopCount = (count > 30000) ? 30000 : 0;
            for (int i = count-1; i > loopCount; i--)
            {
                string[] columns = lines[i].Split(',');
                orderList.Add(columns[0]);
            }
