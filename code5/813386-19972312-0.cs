    //
    //~~> Rest of your code
    //
    
    Range rng = worksheet.Range["$A$1:$C$2"];
    ListObject lo = worksheet.ListObjects.Add(xlSrcRange, rng, Type.Missing, XlYesNoGuess.xlNo);
    lo.ShowHeaders = false;
    Excel.Range rngRowOne = worksheet.get_Range("A1", "A1");
    rngRowOne.EntireRow.Delete(Excel.XlDirection.xlUp);
    
    //
    //~~> Rest of your code
    //
