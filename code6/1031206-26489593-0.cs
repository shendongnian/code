    class MyClass
    {
        public virtual int MyMethod()
        {
            return 5;
        }
    }
    var mock1 = new Mock<MyClass>();
    mock1.Setup(x => x.MyMethod()).Returns(6);
    Console.WriteLine(mock1.Object.MyMethod()); // 6
    var mock2 = new Mock<MyClass>();
    mock2.CallBase = true;
    Console.WriteLine(mock2.Object.MyMethod()); // 5
    var mock3 = new Mock<MyClass>();
    Console.WriteLine(mock3.Object.MyMethod()); // 0 (returns default(int))
