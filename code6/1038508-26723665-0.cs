    for (int i = 0; i < a + 1; i++)
    {
        string fn = tempDV.Table.Rows[AllselectedIndex[i+1]].ItemArray[1].ToString();
        ImgHandler.filename[i] = fn.Trim();
    }
