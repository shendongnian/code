    // first, a class to hold it all
    class MyType {
        public string FileName { get; set; }
        public int CurrentItem { get; set; }
    }
    // .. then you need to declare the Progress instance to hold your type
    var progress = new Progress<MyType>(myType => 
    {
        label1.Text = myType.FileName;
        progressBar1.Value = myType.CurrentItem;
    });
    // then when you're reporting progress you pass an instance of your type
    progress.Report(new MyType {
        FileName = file,
        CurrentItem = i
    });
