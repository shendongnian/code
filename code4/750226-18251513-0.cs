    using System;
    using System.Threading.Tasks;
    namespace AsyncCaptureVariables
    {
        class Program
        {
            public async Task Foo()
            {
                var firstName = "Karl";
                var lastName = "Anderson";
                var street1 = "123 Nowhere Street";
                var street2 = "Apt 1-A";
                var city = "Beverly Hills";
                var state = "California";
                var zip = "90210";
                await Task.Delay(5000);
                Console.WriteLine(firstName);
                Console.WriteLine(city);
            }
            public static void Main()
            {
                var program = new Program();
                Task t = program.Foo();
                t.Wait();
            }
        }
    }
