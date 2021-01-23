    RichTextBox rtb;
    
    Paragraph paragraph = new Paragraph();
    InlineUIContainer uiContainer = new InlineUIContainer();
    uiContainer.Child = new Image(); //Create and add your image here
    paragraph.Inlines.Add(uiContainer);
    rtb.Document.Blocks.Add(paragraph);
    
