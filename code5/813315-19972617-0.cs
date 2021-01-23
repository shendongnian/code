                        XmlDocument doc = new XmlDocument();
                        doc.Load(filename);
                        XmlElement root = doc.DocumentElement;
                        XmlNodeList nodes = root.SelectNodes("Assortment"); 
                        foreach (XmlNode node in nodes)
                        {
                            _dummyCollection1.Add(new DummyClass1()
                            {
                                Наименование = node["Item"].InnerText,
                                Количество = node["Quantity"].InnerText,
                                Цена = node["Price"].InnerText,
                                Сумма = node["Summ"].InnerText,
                                Цена1 = node["Price1"].InnerText,
                                Сумма1 = node["Summ1"].InnerText,
                                Срокгодности = node["ValidDate"].InnerText,
                                Производитель = node["Manufacturer"].InnerText
                            });
                        }
                        BuyDataGrid.ItemsSource = _dummyCollection1;
