            bool doForeach = false;
            foreach (var name in xml.Root.DescendantNodes().OfType<XElement>()
                                               .Select(x => x.Name).Distinct())
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter tx = new XmlTextWriter(sw);
                string str = name.ToString();
                doForeach  = !doForeach ;
                 if(doForeach ){
                foreach (var name1 in xml.Root.DescendantNodes().OfType<XElement>()
                     .Select(x => x.Value).Distinct())
                {
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
