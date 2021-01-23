    string _group_array = Group_Array.Get_Group_Array(3);
    string[] groups = _group_array.Split(',');
    
    foreach (string group in groups)
      {
         GridView grdv = new GridView();
         grdv.DataSource = Connections.isp_GET_GRIDVIEW_DATA("STDNG", group, "", "");
         grdv.DataBind();
    
         gridview_holder.Controls.Add(grdv);
      }
    public static String Get_Group_Array(int count)
    {
        string _cs_group_array = "";
    
        if(count == 1)
        {
            _cs_group_array = "A";
        }
        else if(count == 2)
        {
            _cs_group_array = "A,B";
        }
        else if (count == 3)
        {
            _cs_group_array = "A,B,C";
        }
    
        return _cs_group_array;
    }
