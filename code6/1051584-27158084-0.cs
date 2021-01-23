    using Microsoft.VisualBasic.FileIO;
    //more of the class
    using (TextFieldParser parser = new TextFieldParser("C:\\test\\file.csv"))
    {
        parser.CommentTokens = new string[] { "#" };
        parser.SetDelimiters(new string[] { ";" });
        parser.HasFieldsEnclosedInQuotes = true;
    
        //skip headline if there is any
        //parser.ReadLine();
    
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
                        
            foreach (String s in fields){
                MessageBox.Show(s);
            }
        }
    }
