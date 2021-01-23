     var tableName = "INVENTORY_PRICE";
                var assembly = Assembly.GetExecutingAssembly();
    
                var tip = typeof(Form3);
    
                var t = assembly.GetType(tip.Namespace + "." + tableName);
                if (t != null)
                {
                    var foos = db.GetTable(t);
    
                    foreach (var f in foos)
                    {
                        Console.WriteLine(f + ":");
                        foreach (var property in f.GetType().GetProperties())
                            if (property != null)
                            {
                                var pv = property.GetValue(f, null);
                                Console.WriteLine("   " + property.Name + ":" + pv);
                            }
    
                        Console.WriteLine("------------------------------------------------");
                    }
                }
