    // Create a paragraph with centered page number. See definition of style "Footer".
    Paragraph paragraph = new Paragraph();
    paragraph.AddTab();
    paragraph.AddPageField();
    
    // Add paragraph to footer for odd pages.
    section.Footers.Primary.Add(paragraph);
    // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
    // not belong to more than one other object. If you forget cloning an exception is thrown.
    section.Footers.EvenPage.Add(paragraph.Clone());
