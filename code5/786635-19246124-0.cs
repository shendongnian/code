    List<MyClass> listColors = new List<MyClass>();
    listColors.Add(new MyClass(Color.Blue));
    listColors.Add(new MyClass(Color.Green));
    listColors.Add(new MyClass(Color.Red));
    
    MyClass[] arrayColors = listColors.ToArray();
    arrayColors[2] = new MyClass(Color.Purple);
    
    Console.WriteLine(arrayColors[2].Color1.ToString());
    Console.WriteLine(listColors[2].Color1.ToString());
