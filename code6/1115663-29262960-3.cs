    var input = System.IO.File.OpenRead(myPath);
    var myFirstClass = new MyClass();
    var mySecondClass = new MyClass();
    myFirstClass.Value = input;
    mySecondClass.Value = input;
    System.Diagnostics.Debug.Print(myFirstClass.Equals(mySecondClass).ToString());
