        static void Main(string[] args)
        {
            var config = XDocument.Load(@"fileName");
            var context = Context.LoadRoot(config);
            var doSomeWork = context.Resolve<IDoSomeWork>();
            doSomeWork.Execute();
            Console.ReadLine();
        }
