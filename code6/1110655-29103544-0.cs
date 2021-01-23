            foreach (var tag in objectContainer)
            {
                var property = tag.Path.Substring(tag.Path.IndexOf(".") + 1);
                Console.WriteLine(property);
            }
        }
        Console.ReadLine();
    }
