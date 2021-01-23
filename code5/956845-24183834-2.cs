    StackPanel tempStack = new StackPanel();
    RichTextBox tempRtb = new RichTextBox();
    Paragraph tempPara = new Paragraph();
    
    //tempHLink.Click += Hyperlink_Click;
    
    tempPara.Inlines.Add(new Run { Text = "text 1\ntext 2\n text 3" });
    tempPara.Inlines.Add(new Run { Text = "\nTel.:       " });
    //tempInline.Add(new Hyperlink { new InlineCollection {  =  } }) // "+000 (0) 00 00 00-0"
    tempPara.Inlines.Add(new Run { Text = "\nE-Mail: " });
    //tempInline.Add(new Hyperlink { new InlineCollection {  =  } }) // e-mail@email.com
    
    tempRtb.Blocks.Add(tempPara);
    tempStack.Children.Add(tempRtb);
