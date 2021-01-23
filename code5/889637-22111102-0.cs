    var myEnums = new List<MyEnum>
                      {
                          MyEnum.Value1,
                          MyEnum.Value2,
                          MyEnum.Value1, 
                          MyEnum.Value1,
                          MyEnum.Value2,
                          MyEnum.Value1, 
                          MyEnum.Value1,
                          MyEnum.Value2,
                          MyEnum.Value1
                      };
    
    var streamWriter = new StreamWriter("test.txt");
    
    foreach (var myEnum in myEnums)
    {
        streamWriter.WriteLine(myEnum);
    }
    
    streamWriter.Close();
