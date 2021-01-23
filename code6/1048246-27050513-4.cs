Because I already had a Class in my project named Customer and Field named CustomerID I named it to Customers and CustomerId1 change the code to fit your actual Class Name and Field Names
            List<Customers> customersList =
                            (
                                from e in XDocument.Load(file).Root.Elements("cust")
                                select new Customers
                                {
                                    CustomerID = (int)e.Attribute("custid"),
                                    FirstName = (string)e.Attribute("fname"),
                                    LastName = (string)e.Attribute("lname"),
                                    ShowsNumber = (int)e.Attribute("count_noshow"),
                                    VisitNumber = (int)e.Attribute("count_resos"),
                                    Cancellation = (int)e.Attribute("count_cancel"),
                                }).ToList();
            DataTable dataTable1 = getBasicDataTable();
            ;
            for (int i = 0; i < customersList.Count; i++)
            {
                DataRow datarows = dataTable1.NewRow();
                datarows[0] = customersList[i].CustomerID;
                datarows[1] = customersList[i].FirstName;
                datarows[2] = customersList[i].LastName;
                datarows[3] = customersList[i].ShowsNumber;
                datarows[4] = customersList[i].VisitNumber;
                datarows[5] = customersList[i].Cancellation;
                dataTable1.Rows.Add(datarows);
            }
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                Console.WriteLine(dataTable1.Rows[i]["customerID"]);
            }
