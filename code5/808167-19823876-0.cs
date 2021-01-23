    private static void Dump(object o)
    {
        if (o == null)
        {
            Console.WriteLine("<null>");
            return;
        }
        var type = o.GetType();
        var properties = TypeDescriptor.GetProperties(type);
        Console.Write('{');
        Console.Write(type.Name);
        if (properties.Count != 0)
        {
            Console.Write(' ');
            for (int i = 0, n = properties.Count; i < n; i++)
            {
                if (i != 0)
                    Console.Write("; ");
                    
                var property = properties[i];
                Console.Write(property.Name);
                Console.Write(" = ");
                Console.Write(property.GetValue(o));
            }
        }
        Console.WriteLine('}');
    }
