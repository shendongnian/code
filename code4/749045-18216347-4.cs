    private static void Main(string[] args)
        {
            StreamReader a = new StreamReader(@"A.CSV");
            StreamReader b = new StreamReader(@"B.CSV");
            StreamWriter output = new StreamWriter(@"output.csv");
            Dictionary<string, List<string>> newDict = new Dictionary<string, List<string>>();
            string aLine = a.ReadLine();
            int aLength = aLine.Split(',').Count();
            output.WriteLine(aLine + "," + b.ReadLine());
            while (!a.EndOfStream && !b.EndOfStream)
            {
                //section for A
                string Aline = a.ReadLine();
                string[] Atokens = Aline.Split(','); //split the line into array
                if (newDict.ContainsKey(Atokens[0]))
                {
                    for (int i = 0; i < Atokens.Length; i++)
                    {
                        newDict[Atokens[0]][i] = Atokens[i];
                    }
                }
                else
                {
                    List<string> listToAdd = new List<string>();
                    for (int i = 0; i < Atokens.Length; i++)
                    {
                        listToAdd.Add(Atokens[i]);
                    }
                    newDict.Add(Atokens[0], listToAdd);
                }
            }
            while (!b.EndOfStream)
            {
                //section for B
                string Bline = b.ReadLine();
                string[] Btokens = Bline.Split(',');
                if (newDict.ContainsKey(Btokens[0]))
                {
                    if (newDict[Btokens[0]].Count > aLength)
                    {
                        for (int i = 0; i < Btokens.Length; i++)
                        {
                            newDict[Btokens[0]][i + aLength] = Btokens[i];
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Btokens.Length; i++)
                        {
                            newDict[Btokens[0]].Add(Btokens[i]);
                        }
                    }
                }
                else
                {
                    List<string> listToAdd = new List<string>(aLength);
                    listToAdd.AddRange(Btokens);
                    newDict.Add(Btokens[0], listToAdd);
                }
            }
            foreach (KeyValuePair<string, List<string>> keyValuePair in newDict)
            {
                string outputLine = string.Empty;
                foreach (string s in keyValuePair.Value)
                {
                    if (outputLine != string.Empty)
                    {
                        outputLine += ",";
                    }
                    outputLine += s;
                }
                output.WriteLine(outputLine);
            }
            output.Close();
            // Console.ReadLine();
        }
