    public class MyUsefulClass 
    {
        public MyUsefulClass(string valueToWrite)
        {
            ValueToWrite = valueToWrite;
        }
 
        public string ValueToWrite { get; private set; }
        public void DoSomethingUseful()
        {
            Console.WriteLine("The value is: " + ValueToWrite);
        }
    }
    new MyUsefulClass(MyGlobalVariables.Variable1).DoSomethingUseful();
    new MyUsefulClass("I don't need globals!").DoSomethingUseful();
