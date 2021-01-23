    var ftbe = new FilteredTextBoxExtender();
    ftbe.ID = "ftbe";
    ftbe.TargetControlID = textBox.ID;
    ftbe.FilterType = FilterTypes.Custom; // ** Custom **
    ftbe.FilterMode = FilterModes.ValidChars;
    ftbe.ValidChars = "ABCDEFGHIJKLMNO"; // Allow uppercase A to O only.
