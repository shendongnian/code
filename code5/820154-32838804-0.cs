    using System.Reactive.Linq;   // IMPORTANT - this makes await work!
    // Make sure you set the application name before doing any inserts or gets
    BlobCache.ApplicationName = "AkavacheExperiment";
    var myToaster = new Toaster();
    await BlobCache.UserAccount.InsertObject("toaster", myToaster);
    //
    // ...later, in another part of town...
    //
    // Using async/await
    var toaster = await BlobCache.UserAccount.GetObject<Toaster>("toaster");
    // or without async/await
    Toaster toaster;
    BlobCache.UserAccount.GetObject<Toaster>("toaster")
        .Subscribe(x => toaster = x, ex => Console.WriteLine("No Key!"));
