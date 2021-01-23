    public string createKey(int row,int col)
    {
    return r+","+c;
    }
    
    public string createKey(Cell cell)
    {
    return createKey(cell.row,cell.col);
    }
