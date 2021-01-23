    if (Uri.IsWellFormedUriString(link, UriKind.RelativeOrAbsolute)) {
            //check if there is any paragraph, if not then add a new one            
            Paragraph para = null;
            if(richTextBox1.Blocks.Count == 0 || 
               !(richTextBox1.Blocks.LastBlock is Paragraph)) {
                para = new Paragraph();
                para.Margin = new Thickness(0);
                richTextBox1.Blocks.Add(para);
            } else para = richTextBox1.Blocks.LastBlock;            
            Hyperlink hyper = new Hyperlink(new Run(link));
            hyper.NavigateUri = new Uri(link);
            //add hyperlink to the last Paragraph
            para.Inlines.Add(hyper);            
    }
