    private string URLSource = "https://www.dropbox.com/s/nh3bfzvhpj6e3x1/JapanseEnglish.xml?dl=1";
    
    private void XMLViewer()
    {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(URLSource);
                var response = (HttpWebResponse)request.GetResponse();
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream, true))
                    {
                        XDocument Doc = XDocument.Load(sr);
                        var Kanji = from WordList in Doc.Descendants("Kanji")
                                    select new
                                    {
                                        Word = WordList.Element("Kanji").Value
                                    };
                        foreach (var Word in Kanji)
                        {                            
                            JpnTxt.ItemsSource = Word.ToString();
                        }
                    }
                }
         }
         catch (Exception e)
         {               
               MessageBox.Show(e.Message);
         }
    }
