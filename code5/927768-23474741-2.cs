    DoDragDrop(String.Empty, DragDropEffects.Copy);
    var point = GetCursorPosition();
    var convertedPoint = this.ConvertScreenPointToSlideCoordinates(point);
    // Insert something at the cursor's location:
    var slide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
    slide.Shapes.AddShape(Microsoft.Office.Core.MsoAutoShapeType.msoShapeCloud, convertedPoint.X, convertedPoint.Y, 100, 100);
