    public class main
    {
        public class OneOfThoseView : ISomeView
        {
        }
        public main()
        {
            OneOfThoseView oneOfThose = new OneOfThoseView();
            SomeView x = new SomeView();
            x.SomeParam = oneOfThose;
        }
    }
