    public Worksheet crWsheet<T>(string masterHeading, List<T> list)
    {
           ExcelCreator.HeaderDisplayType headerType = HeaderDisplayType.doubleColumn
    }
    
    
    public Worksheet crWsheet<T>(string masterHeading, List<T> list, string RowName)
    {
            ExcelCreator.HeaderDisplayType headerType = HeaderDisplayType.singleColumn;
    }
