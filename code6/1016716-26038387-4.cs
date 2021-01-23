        static void Main(string[] args)
        {
            var context = Context.CreateRoot();
            context.SetFactory<IDoSomeWork, DoSomeWork>();
            var doSomeWork = context.Resolve<IDoSomeWork>();
            doSomeWork.Execute();
            Console.ReadLine();
        }
