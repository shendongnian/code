    public class ProgramFlow // the listener program
    {
        public ProgramFlow()
        {
            IStep[] steps = new IStep[] { new Step1(), new Step2() };
            foreach (var step in steps)
            {
                step.Step();
                step.StepResult();
            }
        }
    }
    public interface IStep
    {
        void Step();
        void StepResult();
    }
    public class Step1 : IStep
    {
        string stringRead;
        public void Step()
        {
            Console.Write("Input something for Step1: ");
            stringRead = Console.ReadLine();
            Console.WriteLine();
        }
        public void StepResult()
        {
            Console.WriteLine(stringRead);
        }
    }
    public class Step2 : IStep
    {
        string stringRead;
        public void Step()
        {
            Console.Write("Input something for Step2: ");
            stringRead = Console.ReadLine();
            Console.WriteLine();
        }
        public void StepResult()
        {
            Console.WriteLine(stringRead);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProgramFlow programFlow = new ProgramFlow();
            Console.ReadKey();
        }
    }
