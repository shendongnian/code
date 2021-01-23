    public override async Task ProcessRequestAsync(HttpContext context)
    {
         var someLibrary = new SharedLibrary();
         someLibrary.PostProcess = async (x,y) => {
             await ProcessXY(x,y).ConfigureAwait(false);
         }
         await someLibrary.ProcessAsync();
         // write out some content here
    }
    public class SharedLibrary {
      public Func<int,int,Task> PostProcess { get; set; }
      public void Process() {
       // do some processing
        if (PostProcess != null) {
           // call PostProcess synchronously
           PostProcess(1,2).Wait();
        }
       // do some final processing
      }
    }
