            public delegate T LoadObject<T>(SqlDataReader dataReader);
            
            static void Main(string[] args)
            {
                LoadObject<int> del = Test1; //Valid
                LoadObject<string> del1 = Test1; //Compile Error
            }
    
            public static int Test1(SqlDataReader reader)
            {
                return 1;
            }
