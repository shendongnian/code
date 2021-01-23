    private void btnSubmit_Click(object sender, EventArgs e)
    {
         crRpt TI = new crRpt();            
         CrystalReportViewer crv = new CrystalReportViewer();
         Form frmCrViewer = new Form();
         frmCrViewer.Controls.Add(crv);
    
         TextObject tiNo = (TextObject)TI.ReportDefinition.Sections["Section2"].ReportObjects["TIN"];
         tiNo.Text = txtTI.Text.toString();
         crv.ReportSource = TI;
         crv.Dock = Fill;
         frmCrViewer.ShowDialog();
    }
