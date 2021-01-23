    //'Use Passed Word Application ELSE Open new Word Application.
    oWord = this.oWord ?? new Word.Application { Visible = false };
             
    //'Call Property Updating Method
    oWord = UpdateProperties(ref oWord, ref oDoc);
                
    //'Call PrePrint Function (if existing)
    try { oWord.Run("PrePrint"); } catch { }
    //'Refresh All Fields try { oDoc.Fields.Update(); } catch { }
    foreach (Field field in oDoc.Fields)
        field.Update();
    //'Refresh All Shapes
    foreach (Shape shape in oDoc.Shapes)
        shape.TextFrame.TextRange.Fields.Update();
                
    // Print Document
    Print(oWord);
