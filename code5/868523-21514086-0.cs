    using System;
    namespace big_number
    {
    class Program
    {
        static void Main(string[] args)
        {
            decimal d = 0;
            begining:
            try {d = Convert.ToDecimal(Console.ReadLine()); }//<------ HERE IT IS!!!
            catch (Exception EX)// look up what exceptions you want to catch
            { 
                Console.WriteLine("try again\r\n\n" + EX.Message);//display error (if you want)
                d = 0;//just incase
                goto begining; // do not run this code outside of debugger you may get caught in inifinite loop
            }
            //and back again
            string s = "" + d;
            Console.WriteLine(s);//we could just pass d
            Console.ReadLine();
        }
    }
    }
