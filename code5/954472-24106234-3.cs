    private void PrepareDocument(DataRow dr)
    {
        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        {
             ...... all the code above, but with the DataRow passed from the calling method
        }
    }
