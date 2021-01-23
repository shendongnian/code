          System.Web.HttpContext htcont = System.Web.HttpContext.Current;
          Task.Factory.StartNew(() => {
                    System.Web.HttpContext.Current = htcont;
                    DoSomething();
                    ContextPerRequest.DisposeDbContextPerRequest();
           });
