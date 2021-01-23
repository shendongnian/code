    Assembly asm = Assembly.LoadFile(@"C:\TestLibrary.dll");
    Type Class1 = asm.GetType("TestLibrary.Class1") as Type;
    var testClass = Activator.CreateInstance(Class1);                
    PropertyInfo List = Class1.GetProperty("arrayInt"); // <!-- here you are looking for a property!
    int[] arrayTest = (int[])List.GetValue(testClass, null);//throw exception here
    Console.WriteLine("Length of array: "+arrayTest.Count());
    Console.WriteLine("First element: "+arrayTest[0]);
