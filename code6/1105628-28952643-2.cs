    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static int Main(string[] args)
            {
                var results = TestMethod();
                foreach (var item in results)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.planeModel);
                }
                Console.ReadKey();
                return 0;
            }
    
            static List<MainModel> TestMethod()
            {
                var LstMainModel = new List<MainModel>();    
                var ids = new int[] { 1, 2, 3, 4, 5 };
                foreach (var id in ids)
                {
                    LstMainModel.Add(new MainModel { Id = id, planeModel = "TestPlane" });
                }
    
                return LstMainModel;
            }
    
            
        }
    
        class MainModel
        {
            public int Id { get; set; }
            public string planeModel { get; set; }
        }
    
    }
