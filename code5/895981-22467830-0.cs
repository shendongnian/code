    namespace Project1
    {
        public interface IApplication
        {
            // application members here...
        }
        public class Class1
        {
            public static IApplication GetApp()
            {
                return new ExcelApplication(new Microsoft.Office.Interop.Excel.Application());
            }
            private class ExcelApplication : IApplication
            {
                public ExcelApplication(Microsoft.Office.Interop.Excel.Application app)
                {
                     this.app = app;
                }
                // implement IApplication here...
            }
        }
    }
