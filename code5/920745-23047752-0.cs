    class ConflictName
    {
    }
    class GoodName
    {
        static object ConflictName = new ConflictName();
        static Dictionary<string, object> ANOTHERGoodName()
        {
            return new Dictionary<string, object>
            {
                { "txt", ConflictName }
            };
        }
    }
