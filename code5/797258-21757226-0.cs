           // int counter = 0;
            object readOnly = true;
            System.IO.StreamReader file =
             new System.IO.StreamReader(@"C:\Users\noor\Desktop\HIGH LIGHTER\Sample.txt");
            object matchWholeWord = true;
            //string textToFind  = "to";
            //string my = System.IO.File.ReadAllText(@"C:\Users\noor\Desktop\HIGH LIGHTER\Sample.txt");
            //var textToFind = my ;
           // textBox1.Text = textToFind.ToString ();
            while ((line = file.ReadLine()) != null)
            {
                // Define an object to pass to the API for missing parameters
                object missing = System.Type.Missing;
                doc = word.Documents.Open(ref fileName,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing);
                string ReadValue = string.Empty;
                // Activate the document
                doc.Activate();
                /* foreach (Word.Range tmpRange in doc.StoryRanges)
                 {
                     ReadValue += tmpRange.Text;
                 }
             */
                foreach (Word.Range docRange in doc.Words)
                    try
                    {
                        if (docRange.Text.Trim().Equals(line, StringComparison.CurrentCulture) == false )
                        {
                            docRange.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdDarkYellow;
                            docRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdWhite;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                    }
            }
               // counter++;
            
            file.Close();
        
        }
        
