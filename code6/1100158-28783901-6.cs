    public static class TestExtensions
    {
        public static int Num(this MyEnum val)
        {
            int n = 0;
            FieldInfo fi = val.GetType().GetField(val.ToString());
            TestAttribute[] attrs =
            fi.GetCustomAttributes(typeof(TestAttribute),
                                   false) as TestAttribute[];
            if (attrs.Length > 0)
            {
                n = attrs[0].Num;
            }
            return n;
        }
        public static string Name(this MyEnum val)
        {
            string n = "";
            FieldInfo fi = val.GetType().GetField(val.ToString());
            TestAttribute[] attrs =
            fi.GetCustomAttributes(typeof(TestAttribute),
                                   false) as TestAttribute[];
            if (attrs.Length > 0)
            {
                n = attrs[0].Name;
            }
            return n;
        }
        public static string Title(this MyEnum val)
        {
            return Enum.GetName(val.GetType(), val);
        }
    }
