    class MyClass2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Type { get; set; }
    }
        List<MyClass2> myLists = new List<MyClass2>();
        myLists.Add(new MyClass2() { Age = 1, Name = "Mast", Type = 560 });
        myLists.Add(new MyClass2() { Age = 2, Name = "Oli", Type = 778 });
        myLists.Add(new MyClass2() { Age = 3, Name = "AS", Type = 9458 });
        myLists.Add(new MyClass2() { Age = 4, Name = "ABC", Type = 100 });
        int result1 = myLists.FindIndex(T => T.Type == 9458); //2
        int result2 = myLists.FindIndex(T => T.Name == "Oli"); //1
