    var sf = new System.Diagnostics.StackTrace(1).GetFrame(0);
    Console.WriteLine(" File: {0}", sf.GetFileName());
    Console.WriteLine(" Line Number: {0}", sf.GetFileLineNumber());
    // Note that the column number defaults to zero 
    // when not initialized.
    Console.WriteLine(" Column Number: {0}", sf.GetFileColumnNumber());
