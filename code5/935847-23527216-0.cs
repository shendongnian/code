            static void Main(string[] args)
        {
            FieldInfo[] myFields = typeof(ABC).GetFields();
            int A = 1;
            foreach (FieldInfo field in myFields)
                if ((int)field.GetRawConstantValue() == A)
                    Console.WriteLine(field.ToString());
            Console.ReadKey();
        }
        public struct ABC
        {
            public const int x = 1;
            public const int y = 10;
            public const int z = 5;
        }
    
