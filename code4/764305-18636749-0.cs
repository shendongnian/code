    private int columnCount;
    private double leftColumnEdge, rightColumnEdge, columnWidth;
    public int ColumnCount
    {
        get { return columnCount; }
        set
        {
            if (value < 1) value = 1;
            columnCount = value;
        }
    }
