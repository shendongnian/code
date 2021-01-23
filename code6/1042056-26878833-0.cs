        private void button1_Click(object sender, EventArgs e)
        {
            GrapeCity.ActiveReports.SectionReportModel.TextBox txtBox = new GrapeCity.ActiveReports.SectionReportModel.TextBox();
            txtBox.Text = "Hello World!";
            txtBox.Location = new Point(1, 1);
            txtBox.Size = new SizeF(2, 0.5f);
            ((GrapeCity.ActiveReports.SectionReport)reportdesigner.Report).Sections["Detail"].Controls.Add(txtBox);
        }
