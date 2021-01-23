      private void button2_Click(object sender, EventArgs e)
            {
                setFiltersParameters();
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                button1.PerformClick();
                reportViewer1.Visible = true;
            }
