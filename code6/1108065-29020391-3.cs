    using System.Net.Http;
    using System.Threading.Tasks;
    namespace ConsoleApplication1 {
        class Program {
            public static void Main(string[] args) {
                Test().Wait();
            }
            private static async Task Test() {
                HttpClient client = new HttpClient();
                await client.PostAsJsonAsync(
                    "http://localhost/mvcApp/api/survey/",
                    new {
                        value = 10
                    }
                );
            }
        }
    }
