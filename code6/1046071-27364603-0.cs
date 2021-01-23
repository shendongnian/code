            using (var browser = new IE("http://www.domea.dk/sog-bolig/Ledige-boliger/Sider/default.aspx"))
            {
                Table table_name = browser.Table(Find.ById("listTable"));
                foreach (TableRow currRow in table_name.TableRows)
                {
                    foreach (var c in currRow.TableCells)
                    {
                        if (c.Links.Count > 0)
                        {
                            c.Links[0].Click();
                        }
                    }
                }
            }
