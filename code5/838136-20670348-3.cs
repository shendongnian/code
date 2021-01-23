                System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
            string currentLine = null;
            List<ObjectToBeUsed> peopleList = new List<ObjectToBeUsed>();
                                           
            while ((currentLine = file.ReadLine()) != null)
            {
                string[] tokens = Regex.Split(currentLine, @"\t");
                peopleList.Add(new ObjectToBeUsed(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], tokens[3]));
            }
