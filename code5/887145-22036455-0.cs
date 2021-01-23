    List <string> names=new List<string>();
    
         public void FirstDecadeTopNames_Loaded(object sender, RoutedEventArgs e)
            {
                FileStream fs = new FileStream(@"D:\Dokumenter\Skole\6. semester\GUI\Exercises\Exercise4\WpfApplication1\04-babynames.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                
        
                while (!sr.EndOfStream)
                {
                   names.Add(sr.ReadLine());           
                }
                FirstDecadeTopNames.ItemSource=names;
        
            }
