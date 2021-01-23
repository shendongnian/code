    class Program
    {
        static void Main()
        {
            var task = DoStuff();
            Console.WriteLine( "Calling thread returned control to caller" );
            Task.WaitAll( task );
            Console.WriteLine( "Aync method call completed" );
            Console.ReadLine();
        } 
        public static async Task DoStuff()
        {
            var items = new List<TestA>()
            {
                new TestA() { Id = 10 },
                new TestA() { Id = 20 },
                new TestA() { Id = 30 },
            };
            foreach( var ta in items )
            {
                ta.Bs.Add( new TestB() { Id = 1 } );
                ta.Bs.Add( new TestB() { Id = 2 } );
                ta.Bs.Add( new TestB() { Id = 3 } );
            }
            using( var db = new System.Data.SqlClient.SqlConnection() )
            {
                Console.WriteLine( "Entered 'using'" );
                foreach( var a in items )
                {
                    foreach( var b in a.Bs )
                    {
                        if( !await b.GetBoolAsync() )
                        {
                            Console.WriteLine( "{0}: false", a.Id + b.Id );
                        }
                        else
                        {
                            Console.WriteLine( "{0}: true", a.Id + b.Id );
                        }
                    }
                }
                Console.WriteLine( "Leaving 'using'");
            }
            
            Console.WriteLine( "Left 'using'");
        }
    }
    public class TestA
    {
        public int Id { get; set; }
        public List<TestB> Bs { get; set; }
        public TestA()
        {
            Bs = new List<TestB>();
        }
    }
    public class TestB
    {
        public int Id { get; set; }
        public async Task<bool> GetBoolAsync()
        {
            await Task.Delay(1);
            return Convert.ToBoolean( this.Id % 2 );
        }
    }
