       System.IO.Stream src = Application.GetResourceStream(new Uri("solutionname;component/text file name", UriKind.Relative)).Stream;
                using (StreamReader sr = new StreamReader(src))
                  {
                     string text = sr.ReadToEnd();
                  }
 
