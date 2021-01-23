    enum MyEnum
    {
        Enum1, 
        Enum2, 
        Enum3
    }
    class User
    {
        Dictionary<MyEnum, bool> enumList;
        public void InitEnumList()
        {
            enumList = new Dictionary<MyEnum, bool>();
            foreach (var item in Enum.GetValues(typeof(MyEnum)))
            {
                //Set the default key-value pairs
                enumList.Add((MyEnum)item, false);
            }
        }
    }
