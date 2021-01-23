    using System;
    namespace ROT.TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    int index = 1;
                    foreach (dynamic worbook in MSExcelWorkbookRunningInstances.Enum())
                        System.Console.WriteLine("{0}.  '{1}' '{2}'", index++, worbook.Application.Name, worbook.FullName);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Error = '{0}'", ex.Message);   
                }
            }
        }
    }
