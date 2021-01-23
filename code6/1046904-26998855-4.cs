    var o = new List<string>
    {
        "Hist 2368#19:00:00#20:30:00#Large Conference Room",
        "Hist 2368#09:00:00#10:30:00#Large Conference Room",
    };
    var lines = new string[3] { "Meeting#19:00:00#20:30:00#Conference", null, null };
    // Copy the data from o to the end of lines
    o.CopyTo(lines, 1); // Start a 1 to not overwrite the existing data
