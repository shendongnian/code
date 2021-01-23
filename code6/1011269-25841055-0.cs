    const Int32 transparent_Color = -4142;
    //Set Yellow
    var Rng = ActiveSheet.Range["D5:E7"];
    Rng.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
    
    //Set transparent (gridlines come back, so long as you haven't got other code that is interacting with your cells)
    var Rng = ActiveSheet.Range["D5:E7"];
    Rng.Interior.Color = transparent_Color;
