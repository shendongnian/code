     private void TestMethod(dynamic param)
     {
         // Console.Write(param);
    
         foreach (var item in param)
         {
           Console.Write(item);
         }
    }
    
    TestMethod(new int[] { 1, 2, 3 });
    TestMethod(new List<string>() { "x","y","y"});
