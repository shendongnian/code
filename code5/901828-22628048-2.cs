     // Controller
     public class FoosController : ODataController
     {
         public const int Num = 10;
         public static IList<Foo> foos = Enumerable.Range(0, Num).Select(i =>
                new Foo
                {
                    FooId = 100 + i,
                    FooName = "Foo #" + (100 + i)
                }).ToList();
         [EnableQuery]
         public IHttpActionResult Get()
         {
             return Ok(foos);
         }
     }
     public class BarsController : ODataController
     {
         public const int Num = 10;
         public static IList<Bar> bars = Enumerable.Range(0, Num).Select(i =>
                new Bar
                {
                    BarId = 1000 + i,
                    BarName = "Bar #" + (1000 + i)
                }).ToList();
        [EnableQuery]
        public IHttpActionResult Get()
        {
            return Ok(bars);
        }
     }
     public class FooBarRecsController : ODataController
     {
         public const int Num = 10;
         public static IList<FooBarRec> fooBarRecs = Enumerable.Range(0, Num).Select(i =>
                 new FooBarRec
                 {
                       Id = i,
                       Name = "ForBarRec #" + i
                  }).ToList();
         static FooBarRecsController()
         {
            for(int i = 0; i < Num; i++)
            {
                fooBarRecs[i].FooRec = FoosController.foos[i];
                fooBarRecs[i].BarRec = BarsController.bars[i];
            }
         }
         [EnableQuery]
         public IHttpActionResult Get()
         {
             return Ok(fooBarRecs);
         }
     }
