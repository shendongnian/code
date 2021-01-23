    PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
    PowerPoint.SlideRange ppslr = ppApp.ActiveWindow.Selection.SlideRange;
    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    var temporaryPresentation = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoTrue);
    Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = ppApp.ActivePresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];
    for (int i = 1; i <= ppslr.Count; i++)
    {
        var sourceSlide = ppslr[i];
        sourceSlide.Copy();
        var design = sourceSlide.Design;                    
        SlideRange sr = temporaryPresentation.Slides.Paste(); // get newly created slideRange
        sr.Design = sourceSlide.Design; // manually set design
    }
    temporaryPresentation.SaveAs("Temporary", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, Microsoft.Office.Core.MsoTriState.msoTrue);
    temporaryPresentation.Close();
