    [CommandMethod("MARKPOS")]
    public static void MarkPosition()
    {
      Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
      ed.Command(new object[]{"UNDO", "M"});
    }
