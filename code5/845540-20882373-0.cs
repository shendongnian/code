    using System;
    using System.Collections.Generic;
    namespace ExceptionsSample
    {
        class Program
        {
            static void PerformUnsafeActionsWithCollection()
            {
                //ExceptionsList
                var allErrors = new List<Exception>();
                //Collection
                var integersArray = new int[16];
                //Cycle
                foreach (int i in integersArray)
                {
                    try
                    {
                        //Throws an exception (division by zero)
                        Decimal result = Decimal.Divide(i, 0);
                    }
                    catch (Exception exception)
                    {
                        allErrors.Add(exception);
                    }
                }
                if (allErrors.Count > 0) throw new AggregateException(allErrors);
            }
            static void Main(string[] args)
            {
                try
                {
                    PerformUnsafeActionsWithCollection();
                }
                catch(AggregateException aggregateException)
                {
                    foreach(Exception error in aggregateException.InnerExceptions)
                    {
                        Console.WriteLine("Error occured: {0}", error.Message);
                    }
                }
            }
        }
    }
