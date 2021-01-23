    private void btn_Orange_Click(object sender, RibbonControlEventArgs e)
    {
        if(type=="Fill")
        {  
           PowerPoint.Application ppApp = Globals.ThisAddIn.Application;
                PowerPoint.ShapeRange ppshr = ppApp.ActiveWindow.Selection.ShapeRange;
                // here the color RGB is given in format of BGR because interop reads it as BGR and not RGB
                ppshr.Fill.ForeColor.RGB =System.Drawing.Color.FromArgb(0,168,255).ToArgb();
           }
     }
