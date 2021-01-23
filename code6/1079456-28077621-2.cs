<!-- -->    
    class Program
    {
        static void Main()
        {
            IDoSomething worker = InsultMe.Instance;
            worker.DoWhateverItIsThatIDo(); 
    
            worker = InspireMe.Instance;
            worker.DoWhateverItIsThatIDo();
        }
    }
