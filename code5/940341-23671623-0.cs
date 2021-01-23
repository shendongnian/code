    public void addrowtocolors()
    {    
        for (int i = 0; i < result.Count; i++)
        {
             var index = grdColors.Rows.Add();
             grdColors.Rows[index].Cells["Code"].Value = result[i].Code.ToString();
             grdColors.Rows[index].Cells["Desc"].Value = result[i].Desc.ToString();
        }
    }
