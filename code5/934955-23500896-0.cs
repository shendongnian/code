    public override async Task ProcessRequestAsync(HttpContext context)
    {
         var someLibrary = new SharedLibrary();
         someLibrary.PostProcess = async (x,y) => {
             await ProcessXY(x,y).ConfigureAwait(false);
         }
         await someLibrary.ProcessAsync();
         // write out some content here
    }
