            RadGridView grid = new RadGridView();
            grid.Columns.Add("Col1");
            grid.Columns.Add("Col2");
            for (int i = 0; i < 10; i++)
            {
                grid.Rows.Add("cell 1" , "cell 2");
            }
            ExportToExcelML exporter = new ExportToExcelML(grid);
            exporter.RunExport("D:\\test.slx");
