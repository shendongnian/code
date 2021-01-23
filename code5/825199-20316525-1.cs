    foreach (var item in lst)
                {
    
                foreach (var items in (item.GetType()).GetProperties())
                    {
                    Console.WriteLine(items.Name);
                    }
                }
