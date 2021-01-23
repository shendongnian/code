      public EULA()
      {
       InitializeComponent();
    
      //Closing += new CancelEventHandler(EULA_Closing);
    
      TextRange range;
    
      var fileName = "AFICController.Resources.EULA.EULA-Formatted activeARC.rtf";
    
      Assembly assembly = Assembly.GetExecutingAssembly();
    
      var stream = assembly.GetManifestResourceStream(fileName);
    
      if (stream == null)
      {
        Console.WriteLine("File Not Found");
      }
      else
      {
        Console.WriteLine("File Found");
    
      range = new TextRange(EULAParagraph.ContentStart, EULAParagraph.ContentEnd);
    
      range.Load(stream, System.Windows.DataFormats.Rtf);
      }
    
      }
