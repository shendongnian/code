    internal unsafe IndexField[] ParseSortString(string sortString)
    {
        string str;
        int num;
        int num2;
        string[] strArray;
        IndexField[] fieldArray;
        DataColumn column;
        bool flag;
        char[] chArray;
        fieldArray = zeroIndexField;
        if (sortString == null)
        {
            goto Label_011A;
        }
        if (0 >= sortString.Length)
        {
            goto Label_011A;
        }
        // Here the split on the comma char (0x2C) ignoring the fact that 
        // the whole sort expression is inside square brackets????
 
        strArray = sortString.Split(new char[] { 0x2c });
        fieldArray = new IndexField[(int) strArray.Length];
        num2 = 0;
        goto Label_0111;
    Label_0041:
        str = strArray[num2].Trim();
        num = str.Length;
        flag = 0;
        if (num < 5)
        {
            goto Label_007D;
        }
        if (string.Compare(str, num - 4, " ASC", 0, 4, 5) != null)
        {
            goto Label_007D;
        }
        str = str.Substring(0, num - 4).Trim();
        goto Label_00A7;
    Label_007D:
        if (num < 6)
        {
            goto Label_00A7;
        }
        if (string.Compare(str, num - 5, " DESC", 0, 5, 5) != null)
        {
            goto Label_00A7;
        }
        flag = 1;
        str = str.Substring(0, num - 5).Trim();
    Label_00A7:
        if (str.StartsWith("[", 4) == null)
        {
            goto Label_00DE;
        }
        if (str.EndsWith("]", 4) == null)
        {
            goto Label_00D5;
        }
        str = str.Substring(1, str.Length - 2);
        goto Label_00DE;
    Label_00D5:
        throw ExceptionBuilder.InvalidSortString(strArray[num2]);
    Label_00DE:
        column = this.Columns[str];
        if (column != null)
        {
            goto Label_00F7;
        }
        throw ExceptionBuilder.ColumnOutOfRange(str);
    Label_00F7:
        *(&(fieldArray[num2])) = new IndexField(column, flag);
        num2 += 1;
    Label_0111:
        if (num2 < ((int) strArray.Length))
        {
            goto Label_0041;
        }
    Label_011A:
        return fieldArray;
    }
