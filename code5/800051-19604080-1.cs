    static void Main(string[] args)
        {
            MyClass myclass = new MyClass();
            var type = myclass.GetType();
            var fields = type.GetFields().Where(x => x.FieldType != null && x.FieldType.Name == "UserProp`1");
            foreach (var item in fields)
            {
                dynamic userProp = item.GetValue(myclass);
                Console.WriteLine(userProp.IsSet);
            }
            myclass.FirstName.Value = "Mark";
            foreach (var item in fields)
            {
                dynamic userProp = item.GetValue(myclass);
                Console.WriteLine(userProp.IsSet);
            }
            Console.ReadLine();
        }
