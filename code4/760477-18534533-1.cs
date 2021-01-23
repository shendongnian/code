    Excel.Shapes theShapes = excelSheet.Shapes;
    
    foreach (Excel.Shape aShape in theShapes)
    {    
        foreach (var groupItem in aShape.GroupItems)
        {
            var s = (Excel.Shape) groupItem;
            if (s is Excel.OLEObject) continue;
            
            if (s.Type == Microsoft.Office.Core.MsoShapeType.msoFormControl)
            {
               if (s.FormControlType == Excel.XlFormControl.xlDropDown)
               {
                   Console.WriteLine("### " + s.Name);
               }
            }
        }
    }
