    System.IO.Stream src = Application.GetResourceStream(new Uri("solution name;component/text file name", UriKind.Relative)).Stream;
    
    using (StreamReader sr = new StreamReader(src))
    {
      string text = sr.ReadToEnd();
    }
 
