            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(DateTime));
            dt.Rows.Add(DateTime.Now);
            dt.Rows.Add(DateTime.Now.AddDays(1));
            RadGridView grid = new RadGridView();
            this.Controls.Add(grid);
            grid.DataSource = dt;
            GridViewDateTimeColumn dateColumn = (GridViewDateTimeColumn )grid.Columns["date"];
            
            //this will set the format of the date displayed in the cells
            dateColumn.FormatString = "{0:dd.MM.yyyy}";
            //this will set the format of the editor - when the cell is opened for editing
            dateColumn.Format = DateTimePickerFormat.Custom;
            dateColumn.CustomFormat = "dd.MM.yyyy";
