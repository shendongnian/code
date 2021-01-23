    foreach (var item in lst)
                {
                Console.WriteLine("{0} {1} {2}",
                    item.Id, item.Content_Language_en, item.Content_Language_de);
    
                foreach (var items in (item.GetType()).GetProperties())
                    {
                    Console.WriteLine(items.Name);
                    }
                }
