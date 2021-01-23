    Excel.Shapes theShapes = excelSheet.Shapes;
    foreach (Excel.Shape aShape in theShapes)
    {
        if (aShape.Type == Microsoft.Office.Core.MsoShapeType.msoFormControl)
        {
            if (aShape.FormControlType == Excel.XlFormControl.xlDropDown)
            {
                Console.WriteLine("### " + aShape.Name);
            }
        }
    }
