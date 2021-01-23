    cSTLBinaryDataModel stlFile = new cSTLBinaryDataModel(1);
    cSTLBinaryDataModel stlFile2 = new cSTLBinaryDataModel(2);
    var progress = new Progress<cReadUpdateEventArgs>(update =>
    {
      switch (update.id)
      {
        case 1:
          progressBar1.Value = Convert.ToInt32(update.percentage * 10);
          break;
        case 2:
          progressBar2.Value = Convert.ToInt32(update.percentage * 10);
          break;
      }
    });
    await Task.WhenAll(
        Task.Run(() => stlFile.ReadFromFileAsync(@"C:\temp\Test.stl", progress)),
        Task.Run(() => stlFile2.ReadFromFileAsync(@"C:\temp\Test.stl", progress)));
    button1.Enabled = true;
