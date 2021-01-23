    var ftbe = new FilteredTextBoxExtender();
    ftbe.ID = "ftbe";
    ftbe.TargetControlID = "textboxID";
    ftbe.FilterType = FilterTypes.UppercaseLetters; // ** Uppercase **
    ftbe.FilterMode = FilterModes.ValidChars;
    ftbe.ValidChars = "A-O"; // Allow uppercase A to O only.
