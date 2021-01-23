    WindowDossierProtection wdPr = new WindowDossierProtection();
    wdPr.TopLevel = false;
    this.Controls.Add(wdPr);
    wdPr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
    wdPr.Dock = DockStyle.Fill;
    wdPr.BringToFront();
    wdPr.Show();
