    string pictureFileName = "C:\\temp\\test.jpg"; 
    Application pptApplication = new Application();
    Microsoft.Office.Interop.PowerPoint.Slides slides;
    Microsoft.Office.Interop.PowerPoint._Slide slide;
    Microsoft.Office.Interop.PowerPoint.TextRange objText;
    // Create the Presentation File
    Presentation pptPresentation = pptApplication.Presentations.Add(MsoTriState.msoTrue);
    Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];
    // Create new Slide
    slides = pptPresentation.Slides;
    slide = slides.AddSlide(1, customLayout);
    // Add title
    objText = slide.Shapes[1].TextFrame.TextRange;
    objText.Text = "test";
    objText.Font.Name = "Arial";
    objText.Font.Size = 32;
    objText = slide.Shapes[2].TextFrame.TextRange;
    objText.Text = "Content goes here\nYou can add text\nItem 3";
    Microsoft.Office.Interop.PowerPoint.Shape shape = slide.Shapes[2];
    slide.Shapes.AddPicture(pictureFileName,Microsoft.Office.Core.MsoTriState.msoFalse,Microsoft.Office.Core.MsoTriState.msoTrue,shape.Left, shape.Top, shape.Width, shape.Height);
    slide.NotesPage.Shapes[2].TextFrame.TextRange.Text = "Test";
    pptPresentation.SaveAs(@"c:\temp\test.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);
    //pptPresentation.Close();
    //pptApplication.Quit();
