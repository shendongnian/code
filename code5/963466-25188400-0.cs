    using AutoCAD;
    namespace test
    {
    class Program
    {
        static void Main(string[] args)
        {
            AutoCAD.AcadApplication app;
            app = new AcadApplication();
            app.Visible = true;
            Console.Read();
        }
    }
    }
