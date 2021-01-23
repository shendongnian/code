    // declare below variables...
    try
    {
        bookMark = MyBookMarks.Item(bookmark);
        columns = cmd.Columns;
        item = columns.Item(bookmark);
        range = bookMark.Range;
        range.Text = item.ToString();
    }
    catch (Exception ex)
    {
        // ...
    }
    finally
    {
        System.Runtime.InteropServices.Marshal.ReleaseComObject(bookMark);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(columns);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(item);
        System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
        bookMark = null;
        columns = null;
        item = null;
        range = null;
        // A good idea depending on who you talk to...
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
