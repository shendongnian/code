      foreach (RepeaterItem i in Repeater1.Items)
    {
        GridView _gv = (GridView)i.FindControl("gvProduct");
        foreach (GridViewRow _g in _gv.Rows)
              {
        CheckBox chk = (CheckBox)_g.FindControl("cbCheckRow") ;
        if(chk.Checked)
         {
          .......
         }
             }
    }
