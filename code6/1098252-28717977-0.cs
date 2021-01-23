    private void btnCalibrifyText_Click(object sender, RibbonControlEventArgs e)
    {
        try
        {
            PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
            PowerPoint.SlideRange ppslr = ppApp.ActiveWindow.Selection.SlideRange;
            int slidecount = ppApp.ActiveWindow.Presentation.Slides.Count;
            for (int i = 1; i <= slidecount; i++)
            {
                ppApp.ActiveWindow.Presentation.Slides.Range(i).Select();
                ppApp.ActivePresentation.Slides.Range(i).Shapes.SelectAll();
                PowerPoint.ShapeRange ppshr = ppApp.ActiveWindow.Selection.ShapeRange;
                // new version
                foreach (PowerPoint.Shape shape in ppshr)
                {
                    changeFont(shape);
                }
            }
            MessageBox.Show("Done!");
        }
        catch (COMException comEx)
        {
            Debug.WriteLine("COMException: " + comEx.Message + comEx.StackTrace);
            MessageBox.Show(comEx.Message);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Exception: " + ex.Message + ex.StackTrace);
            MessageBox.Show(ex.Message);
        }
    }
    private void changeFont(PowerPoint.Shape shape)
    {
        if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
        {
            foreach (PowerPoint.Shape childShape in shape.GroupItems)
            {
                changeFont(childShape);
            }
        }
        else if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
        {
            if (shape.TextFrame.TextRange.Text != "")
            {
                var text1 = shape.TextFrame.TextRange;
                text1.Font.Name = "Calibri Light";
            }
        }
    }
