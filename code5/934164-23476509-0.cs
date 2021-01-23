        static void Main(string[] args)
        {
            var rawItems = new[] { new { ExpenseID = 0, PersonID = 0, SeqNumb = 0, HistorySeqNumb = 0, HistoryCode = 0 } }.ToList();
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\data.xml", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                XmlReader reader = XmlReader.Create(fs);                
                XDocument doc = XDocument.Load(reader);
                fs.Flush();
                doc.Root.Elements("Item").ToList().ForEach(i =>
                {
                    var xExpenseID = Convert.ToInt32(i.Attribute("ExpenseID").Value);
                    var xPersonID = Convert.ToInt32(i.Attribute("PersonID").Value);
                    var xSeqNumb = Convert.ToInt32(i.Attribute("SeqNumb").Value);
                    var xHistorySeqNumb = Convert.ToInt32(i.Attribute("HistorySeqNumb").Value);
                    var xHistoryCode = Convert.ToInt32(i.Attribute("HistoryCode").Value);
                    rawItems.Add(new { ExpenseID = xExpenseID, PersonID = xPersonID, SeqNumb = xSeqNumb, HistorySeqNumb = xHistorySeqNumb, HistoryCode = xHistoryCode });
                });
            }
            //sort
            var sortedItems = rawItems.Where(w => (w.HistoryCode == 0)).ToList();
            sortedItems.Sort((emp1, emp2) => emp2.ExpenseID.CompareTo(emp1.ExpenseID));
                
            Console.Write("ExpenseID".PadRight(16, ' '));
            Console.Write("PersonID".PadRight(16, ' '));
            Console.Write("SeqNumb".PadRight(16, ' '));
            Console.Write("HistorySeqNumb".PadRight(16, ' '));
            Console.WriteLine("HistoryCode".PadRight(16, ' '));
            foreach (var item in sortedItems)
            {
                Console.Write(item.ExpenseID.ToString().PadRight(16, ' '));
                Console.Write(item.PersonID.ToString().PadRight(16, ' '));
                Console.Write(item.SeqNumb.ToString().PadRight(16, ' '));
                Console.Write(item.HistorySeqNumb.ToString().PadRight(16, ' '));
                Console.WriteLine(item.HistoryCode.ToString().PadRight(16, ' '));
            }
            Console.ReadKey(true);
        }
