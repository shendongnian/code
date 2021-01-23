    private static string GetSizeValue(string columnKeyValue, SomeArgsType e)
        {
            switch (columnKeyValue)
            {
                case "size":
                    return e.Name.Length;
                case "user":
                    return e.Name.User; // or something else
            }
            throw new Exception("Invalid Entry");
        }
