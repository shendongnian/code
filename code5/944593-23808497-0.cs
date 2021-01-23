    // Create the Presentation File
    Application pptApplication = new Application();
    Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoTrue);
    CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[PpSlideLayout.ppLayoutText];
    // Create new Slide
    var slides = pptPresentation.Slides;
    var slide = slides.AddSlide(1, customLayout);
    // Add title
    slide.Shapes[1].TextFrame.TextRange.Text = "Title of slide.com";
    // Add items to list
    var bulletedList = slide.Shapes[2]; // Bulleted point shape
    var listTextRange = bulletedList.TextFrame.TextRange;
    listTextRange.Text = "Content goes here\nYou can add text\nItem 3";
    // Change the bullet character
    var format = listTextRange.Paragraphs().ParagraphFormat;
    format.Bullet.Character = (char)9675;
    pptPresentation.SaveAs(@"c:\temp\fppt.pptx", PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
    pptPresentation.Close();
    pptApplication.Quit();
