    Microsoft.Office.Interop.PowerPoint.Application app = null;
    Microsoft.Office.Interop.PowerPoint.Presentation pres = null;
    app = new Microsoft.Office.Interop.PowerPoint.Application();
    app.SlideShowNextSlide += new Microsoft.Office.Interop.PowerPoint.EApplication_SlideShowNextSlideEventHandler(app_SlideShowNextSlide);
    pres = app.Presentations.Open(filename,
                Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse);
    pres.SlideShowSettings.ShowWithAnimation = Microsoft.Office.Core.MsoTriState.msoTrue;
    pres.SlideShowSettings.Run();
    pres.SlideShowWindow.View.First();
