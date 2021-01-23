    public void addrowtocolors()
    {    
        for (int i = 0; i < list.Count; i++)
        {
             var index = grdColors.Rows.Add();
             grdColors.Rows[index].Cells["Code"].Value = list[i].Code.ToString();
             grdColors.Rows[index].Cells["Desc"].Value = list[i].Desc.ToString();
        }
    }
