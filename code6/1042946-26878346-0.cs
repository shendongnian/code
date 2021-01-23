    private void gridEXMon_DoubleClick(object sender, EventArgs e)
        {
            if (e.Row.RowIndex < 0)
                return;
            ReportInfo report = new ReportInfo();
            String System = Convert.ToInt32(e.Row.Cells["System"].Value);
            String Manager = Convert.ToString(e.Row.Cells["Manager"].Value);
            String Function = Convert.ToDecimal(e.Row.Cells["Function"].Value);
            String Speed = Convert.ToInt32(e.Row.Cells["Speed"].Value);
            report.ShowDialog(System, Manager, Function, Speed);
        }
