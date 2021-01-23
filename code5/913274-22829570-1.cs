            int counter = 0;
            foreach (var name in xml.Root.DescendantNodes().OfType<XElement>()
                                               .Select(x => x.Name).Distinct())
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                string str = name.ToString();
                int localCounter = -1;
                {
                foreach (var name1 in xml.Root.DescendantNodes().OfType<XElement>()
                     .Select(x => x.Value).Distinct())
                {
                    localCounter++;
                    if(localCounter < counter)
                       {
                         
                         continue;
                        }
                   counter++;
                    column = new WebGridColumn();
                    column.ColumnName = str;
                    StringWriter sw1 = new StringWriter();
                    XmlTextWriter tx1 = new XmlTextWriter(sw1);
                    string str1 = name1.ToString();
                    column.Format = (item) => str1;
                    listelem.Add(column);
                    break;
                }
                }
            }
