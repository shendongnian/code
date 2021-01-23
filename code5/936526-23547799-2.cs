    public object[] ItemArray
    {
        get
        {
            int num;
            object[] objArray;
            DataColumn column;
            int num2;
            num2 = this.GetDefaultRecord();
            objArray = new object[this._columns.Count];
            num = 0;
            goto Label_0037;
        Label_001C:
            column = this._columns[num];
            objArray[num] = column[num2];
            num += 1;
        Label_0037:
            if (num < ((int) objArray.Length))
            {
                goto Label_001C;
            }
            return objArray;
        }
    }
