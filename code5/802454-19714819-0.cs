    try
    {
      Microsoft.Office.Core.MsoTriState ofalse = Microsoft.Office.Core.MsoTriState.msoFalse;
      Microsoft.Office.Core.MsoTriState otrue = Microsoft.Office.Core.MsoTriState.msoTrue;
      Microsoft.Office.Interop.PowerPoint.Application app = new Microsoft.Office.Interop.PowerPoint.Application();
      app.Visible = otrue
      app.Activate();
      Microsoft.Office.Interop.PowerPoint.Presentations ps = app.Presentations;
      Microsoft.Office.Interop.PowerPoint.Presentation p = ps.Open(sourceFilename,ofalse,otrue,otrue);
      p.SaveAs(destinationFileName, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPNG);
      app.Quit();
    }
