            DataTable ds = new DataTable();
            ds = null;
            GV.DataSource = ds;
            GV.DataBind();
            for (int i = 0; GV.Columns.Count > i; )
            {
                GV.Columns.RemoveAt(i);
            }
            ViewState["CurrentData"] = null;
