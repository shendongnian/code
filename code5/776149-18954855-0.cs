    List<object> GetValueList(int inRow, int fromColumn, int toColumn)
    {
        List<object> MyList = new List<object>(toColumn - fromColumn + 1);
        for(int i=fromColumn; i<=toColumn; i++)
            MyList.Add(WS.Cells[inRow, i].Value);
        return MyList;
    }
