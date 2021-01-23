    class Program
    {
        static void Main( string[] args )
        {
            using( var db = new TestContext() )
            {
                db.Database.Log += Console.WriteLine;
                var query = from mfg in db.Manufacturers
                            where mfg.Name.Contains( "Inc." )
                            select mfg;
                var count = query.Count();
            }
            Console.ReadLine();
        }
    }
