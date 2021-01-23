     void textBlock_TargetUpdated(object sender, DataTransferEventArgs e)
     {
            string text = textBlock.Text;
            
            if (text.Contains("<b>"))
            {
                textBlock.Text = "";
                int startIndex = text.IndexOf("<b>");
                int endIndex = text.IndexOf("</b>");
                textBlock.Inlines.Add(new Run(text.Substring(0, startIndex)));
                textBlock.Inlines.Add(new Bold(new Run(text.Substring(startIndex + 3, endIndex - (startIndex + 3)))));
                textBlock.Inlines.Add(new Run(text.Substring(endIndex + 4)));
            }
        }
