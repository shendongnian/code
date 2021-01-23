    for (int i = 0; i < 10; i++) 
        {
            gc[i] = new GridView();
            gc[i].ID = "gv" + i;
            gc[i].CopyBaseAttributes(GridView1);
            gc[i].AlternatingRowStyle.CopyFrom(GridView1.AlternatingRowStyle);
            gc[i].BorderStyle = GridView1.BorderStyle;
            gc[i].ControlStyle.CopyFrom(GridView1.ControlStyle);
            gc[i].EditRowStyle.CopyFrom(GridView1.EditRowStyle);
            gc[i].EmptyDataRowStyle.CopyFrom(GridView1.EmptyDataRowStyle);
            gc[i].FooterStyle.CopyFrom(GridView1.FooterStyle);
            gc[i].HeaderStyle.CopyFrom(GridView1.HeaderStyle);
            gc[i].RowStyle.CopyFrom(GridView1.RowStyle);
            gc[i].SelectedRowStyle.CopyFrom(GridView1.SelectedRowStyle);
            gc[i].ShowHeaderWhenEmpty = true;
            gc[i].RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);
            //gc[i].EmptyDataText = "No ROWS Found in the particular month";
            }
