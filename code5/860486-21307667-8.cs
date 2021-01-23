    public static class TestApp
    {
        [Route("/TheSimpsons", "GET")]
        public class TheSimpsonsRequest {}
        [Route("/Superheros", "GET")]
        public class SuperherosRequest {}
        public class TestController : Service
        {
            [BasicAuth("The Simpsons", "Simpsons")] // Requires a 'Simpsons' user
            public object Get(TheSimpsonsRequest request)
            {
                return new { Town = "Springfield", Mayor = "Quimby" };
            }
            [BasicAuth("Superheros")] // Requires a user from 'Superheros'
            public object Get(SuperherosRequest request)
            {
                return new { Publishers = new[] { "Marvel", "DC" } };
            }
        }
    }
