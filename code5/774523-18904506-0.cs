        public void test()
        {
            List<MyEnum> list = new List<MyEnum>();
            foreach (MyEnum item in Enum.GetValues(typeof(MyEnum)))
            {
                list.Add(item);
            }
        }
