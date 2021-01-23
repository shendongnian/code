    public static class TypeExt
    {             
        public static bool IsBuiltIn(string _type)
        {
            return Type.GetType(_type) == null;
        }
    }
    // To call it:
    TypeExt.IsBuiltIn("System.Int32")
