      XDocument xdoc = XDocument.Load(@"C:\Users\max\Desktop\xml_answer\ConsoleApplication1\ConsoleApplication1\XMLFile1.xml");
            var content1 = from root in xdoc.Descendants("GroceryBag")
                          select root.Elements();
            var list = content1.ToList();
            XDocument xdoc1 = XDocument.Load(@"C:\Users\max\Desktop\xml_answer\ConsoleApplication1\ConsoleApplication1\XMLFile2.xml");
            var content2 = from root in xdoc.Descendants("GroceryBag")
                           select root.Elements();
            var list2 = content2.ToList();
            XDocument xdoc3 = XDocument.Load(@"C:\Users\max\Desktop\xml_answer\ConsoleApplication1\ConsoleApplication1\XMLFile3.xml");
            var content3 = from root in xdoc.Descendants("GroceryBag")
                           select root.Elements();
            var list3 = content3.ToList();
            list.AddRange(list2);
            list.AddRange(list3);
            var tot = list;
