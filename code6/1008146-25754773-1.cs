    public static void GenericTester()
    {
        var objA = new ObjectA {ObjB = new ObjectB {ObjC = new ObjectC {Text = "Hello"}}};
        Console.WriteLine(objA.ObjB.ObjC.Text);
    }
