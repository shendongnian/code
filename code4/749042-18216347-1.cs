    private static void Main(string[] args)
        {
            StreamReader a = new StreamReader(@"A.CSV");
            StreamReader b = new StreamReader(@"B.CSV");
            StreamWriter output = new StreamWriter(@"output.csv");
            Dictionary<string, WbsElement> newDict = new Dictionary<string, WbsElement>();
            output.WriteLine(a.ReadLine() + "," + b.ReadLine());
            while (!a.EndOfStream && !b.EndOfStream)
            {
                //section for A
                string Aline = a.ReadLine();
                string[] Atokens = Aline.Split(','); //split the line into array
                if (newDict.ContainsKey(Atokens[0]))
                {
                    newDict[Atokens[0]].PurchasingDocument = Atokens[1];
                    newDict[Atokens[0]].PurchaseOrderText = Atokens[2];
                    newDict[Atokens[0]].ValCoAreaCrcyA = Atokens[3];
                }
                else
                {
                    WbsElement elementToAdd = new WbsElement();
                    elementToAdd.PurchasingDocument = Atokens[1];
                    elementToAdd.PurchaseOrderText = Atokens[2];
                    elementToAdd.ValCoAreaCrcyA = Atokens[3];
                    newDict.Add(Atokens[0], elementToAdd);
                }
            }
            while (!b.EndOfStream)
            {
                //section for B
                string Bline = b.ReadLine();
                string[] Btokens = Bline.Split(',');
                if (newDict.ContainsKey(Btokens[0]))
                {
                    newDict[Btokens[0]].RefDocumentNumber = Btokens[1];
                    newDict[Btokens[0]].ValCoAreaCrcyB = Btokens[2];
                    newDict[Btokens[0]].Name = Btokens[3];
                }
                else
                {
                    WbsElement elementToAdd = new WbsElement();
                    elementToAdd.RefDocumentNumber = Btokens[1];
                    elementToAdd.ValCoAreaCrcyB = Btokens[2];
                    elementToAdd.Name = Btokens[3];
                    newDict.Add(Btokens[0], elementToAdd);
                }
            }
            foreach (KeyValuePair<string, WbsElement> keyValuePair in newDict)
            {
                output.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", keyValuePair.Key, keyValuePair.Value.PurchasingDocument,
                                 keyValuePair.Value.PurchaseOrderText, keyValuePair.Value.ValCoAreaCrcyA,
                                 keyValuePair.Key,
                                 keyValuePair.Value.RefDocumentNumber, keyValuePair.Value.ValCoAreaCrcyB,
                                 keyValuePair.Value.Name));
            }
            output.Close();
            // Console.ReadLine();
        }
