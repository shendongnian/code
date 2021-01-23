    delegate void theTargetFunction(int chunk);
 
    static void Main(string[] args)
    {
      TestClass class2 = new TestClass();
      byte[] theChenk = class2.GetData();
      SendData(50, class2.GetData());
    }
    public static void SendData(int data, dynamic targetFunction)
    {
      theTargetFunction del1 = new theTargetFunction(TheDelegate);
      del1.DynamicInvoke(data);
    }
    static void TheDelegate(int chunk)
    {
      Console.WriteLine(chunk);
    }
