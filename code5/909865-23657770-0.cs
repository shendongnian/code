    public static async Task ProcessData(IProgress<int> ReadProg, IProgress<int> UploadProg)
    {
          var loadBuffer = new BufferBlock<string>();
          var parseBlock = new TransformBlock<string, MyObject>(async s =>
          {
              if(await DoSomething(s))
                  ReadProg.Report(1);
              else
                  ReadProg.Report(-1);
           });
           ...
           //setup of other blocks
           //link blocks
           //feed data into pipeline by adding data into the head block: loadBuffer
           //await ALL continuation tasks of the blocks
    }
