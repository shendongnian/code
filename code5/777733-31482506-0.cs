    // Parameters passed on to the function that creates the PDF 
    String headerText = "Your header text";
    String footerText = "Page";
    
    // Define a font and font-size in points (plus f for float) and pick a color
    // This one is for both header and footer but you can also create seperate ones
    Font fontHeaderFooter = FontFactory.GetFont("arial", 8f);
    fontHeaderFooter.Color = Color.GRAY;
    
    // Apply the font to the headerText and create a Phrase with the result
    Chunk chkHeader = new Chunk(headerText, fontHeaderFooter);
    Phrase p1 = new Phrase(chkHeader);
    
    // create a HeaderFooter element for the header using the Phrase
    // The boolean turns numbering on or off
    HeaderFooter header = new HeaderFooter(p1, false);
    
    // Remove the border that is set by default
    header.Border = Rectangle.NO_BORDER;
    // Align the text: 0 is left, 1 center and 2 right.
    header.Alignment = 1;
    
    // add the header to the document
    document.Header = header;
    
    // The footer is created in an similar way
    
    // If you want to use numbering like in this example, add a whitespace to the
    // text because by default there's no space in between them
    if (footerText.Substring(footerText.Length - 1) != " ") footerText += " ";
    
    Chunk chkFooter = new Chunk(footerText, fontHeaderFooter);
    Phrase p2 = new Phrase(chkFooter);
    
    // Turn on numbering by setting the boolean to true
    HeaderFooter footer = new HeaderFooter(p2, true);
    footer.Border = Rectangle.NO_BORDER;
    footer.Alignment = 1;
    
    document.Footer = footer;
    
    // Open the Document for writing and continue creating its content
    document.Open();
