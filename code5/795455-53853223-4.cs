    class Program
    {
        static void Main(string[] args)
        {
            var fieldList = new List<IField>()
            {
                new Field<string>()
                {
                    Value = "Hello World!", 
                    Length = 12, 
                    Name = "A string"
                },
                new Field<int>()
                {
                    Value = 4711,
                    Length = sizeof(int),
                    Name = "An integer value"
                },
                new Field<double>()
                {
                    Value = 2.4,
                    Length = sizeof(double),
                    Name = "A double value"
                },
            };
            foreach (var field in fieldList)
            {
                if (field.Type == typeof(string))
                {
                    PrintField(field, "String value:");
                }
                else if (field.Type == typeof(int))
                {
                    PrintField(field, "Integer value:");
                }
                else if (field.Type == typeof(double))
                {
                    PrintField(field, "Double value:");
                }
            }
        }
        static void PrintField(IField field, string info)
        {
            Debug.WriteLine(info);
            Debug.WriteLine($"\tName: {field.Name}, Length: {field.Length}, Value: {field}");
        }
    }
