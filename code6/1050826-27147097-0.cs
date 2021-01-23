     using (var northwind = new DataClassesDataContext())
                {
    
                    var newSupplier = new Supplier();
                    
                        //SupplierID = northwind.Suppliers.Max(id => id.SupplierID) + 1,
                    newSupplier.CompanyName = "Doe Electrical";
                    newSupplier.ContactName = "John Doe";
                    newSupplier.ContactTitle = "Mr.";
                    newSupplier.Address = "123 Fake Street";
                    newSupplier.City = "Dublin";
                    newSupplier.Region = null;
                    newSupplier.PostalCode = "123456";
                    newSupplier.Country = "Ireland";
                    newSupplier.Phone = "123456789";
                    newSupplier.Fax = "987654321";
                    newSupplier.HomePage = "Hello World!";
                    
    
                    northwind.Suppliers.InsertOnSubmit(newSupplier);
                   
    
                    try
                    {
                        northwind.SubmitChanges();
    
                        //get identity id  for supplierid
                        var supplierid = newSupplier.SupplierID.ToString();
                        
                        Console.WriteLine("Inserted");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.ReadLine();
                        throw;
                    }
                }
