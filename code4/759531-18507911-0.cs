    public class FirstProcess
    {
        public virtual void Calculate(int x = 10)
        {
            Console.WriteLine("First Process  X :{0}", x);
        }
    }
    public class SecondProcess : FirstProcess
    {
        public override void Calculate(int x = 20)
        {
            Console.WriteLine("Second Process  X :{0}", x);
        }
    }
    var secondProcess = new SecondProcess();
    var firstProcess = (FirstProcess) secondProcess;
    secondProcess.Calculate(); // "Second Process X: 20"
    firstProcess.Calculate();  // "Second Process X: 10"
