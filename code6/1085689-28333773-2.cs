    class Program
    {
        static void Main(string[] args)
        {
            OptionsViewModel model = new OptionsViewModel();
            model.Init();
            Console.WriteLine(model.Save());
        }
    }
