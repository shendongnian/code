    private void Print_Test()
            {
                PrintDialog dlg = new PrintDialog();
                if (dlg.ShowDialog() == false) return;
                int i = 1;
    
                Size pageSize = new Size(dlg.PrintableAreaWidth, dlg.PrintableAreaHeight); //I found this Size object very important.  Without it I only got an empty page
                ReportPrintForm rf;
                foreach (KeyValuePair<String, Report> kvp in ((App)Application.Current).Reports)
                {
                    rf = new ReportPrintForm(kvp.Value);
                    rf.Measure(pageSize);
                    rf.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));
                    dlg.PrintVisual(rf, "Job_" + i);
                    i++;
                }
            }
