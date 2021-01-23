       bool? pass = null; //this line has changed
       foreach (Software.dsBDD.list_table21 row in dataTable.Rows)
            {
                PictureBox box;
                MemoryStream stream;
                Panel panel;
                Label label;
                if (this.pass.HasValue && this.end)
                {
                   pass = this.pass;
                }
                if ((pass.GetValueOrDefault() && pass.HasValue) || row.view_only)
            }
