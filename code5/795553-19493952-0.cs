    private static void saveAndClose(Workbook book, string filename)
    {
        try
        {
            File.Delete(filename);
        }
        catch { }
        if (!File.Exists(filename))
            book.SaveAs(filename);
        book.Close(false);
    }
