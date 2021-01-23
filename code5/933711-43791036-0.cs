    private void ChangeControlStatus(bool status)
        {
            int i = 1;
            //loop through 6 gridviews
            for (i = 1; i <= 6; i++)
            {
                //enable/disable all grids on the page  
                GridView gv = UpdatePanel1.FindControl("UpdatePanel1").FindControl("Gridview" + i) as GridView;
                gv.Enabled = status;
            } }
