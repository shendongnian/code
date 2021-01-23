    var clipObj = Clipboard.GetDataObject();
    if (clipObj != null && clipObj.GetDataPresent(DataFormats.CommaSeparatedValue))
    {
        var csv = clipObj.GetData(DataFormats.CommaSeparatedValue) as string;
    	csv.Dump();
    }
