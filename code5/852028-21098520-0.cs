    using System.Reflection;
    public MainPage()
    {
      this.InitializeComponent();
      Assembly asm = typeof(MainPage).GetTypeInfo().Assembly;
      Stream stream = asm.GetManifestResourceStream("YourNamespace.filename.extension");
      
      ConvertToFileAndCopyToLocalDirectory(stream);
    }
