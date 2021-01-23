        class ReflectionTest
    {
        public static int Height = 2;
        public static int Width = 10;
        public static int Weight = 12;
        public static string Name = "Got It";
    
        public override string ToString()
        {
            string result = string.Empty;
            Type type = typeof(ReflectionTest); 
            FieldInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                string name = field.Name; 
                object temp = field.GetValue(null);
                result += "Name:" + name + ":" + temp.ToString() + System.Environment.NewLine;
            }
            return result;
        }
    
    }
