    using System.Drawing.Printing;
    // ... 
    
    private void xrSubreport1_BeforePrint(object sender, PrintEventArgs e) {
        ((XtraReport2)((XRSubreport)sender).ReportSource).CatID.Value = 
            Convert.ToInt32(GetCurrentColumnValue("CategoryID"));
    }
