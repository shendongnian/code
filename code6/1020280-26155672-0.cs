            Table[] T = new Table[] { Table1, Table2, Table3, Table4, Table5, Table6, Table7, Table8, Table9, Table10 };
            foreach (Table t in T)
            {
                t.Visible = false;
            }
            for (int i = 0; i < ddlServer.SelectedIndex; i++)
            {
                T[i].Visible = true;
            }
