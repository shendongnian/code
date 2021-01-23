    using System;
    
    class Test
    {
        static void Main()
        {
            DateTime dtUtc = new System.DateTime(2014, 4, 29, 9, 10, 30, System.DateTimeKind.Utc);
            DateTime dtLocal = new System.DateTime(2014, 4, 29, 9, 10, 30, System.DateTimeKind.Local);
            DateTime dtU = new System.DateTime(2014, 4, 29, 9, 10, 30, System.DateTimeKind.Unspecified);
            Console.WriteLine(dtUtc.ToBinary().ToString("X16"));
            Console.WriteLine(dtLocal.ToBinary().ToString("X16"));
            Console.WriteLine(dtU.ToBinary().ToString("X16"));
        }
    }
