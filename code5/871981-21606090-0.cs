    {
    //...
        var task = Task.Factory.StartNew(() => MyMethod(number));`.
    //...
    }
    private void MyMethod(int number)
    {
        Console.WriteLine(number);
    }
