    using System.Threading.Tasks;
    Task.Factory.StartNew(() =>
    {
      // Do something and wait in the background...
    })
    .ContinueWith(t =>
    {
      // and continue here after we are done.
    });
