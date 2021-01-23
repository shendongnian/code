    // Hook up the handler in InitializeComponents
    this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
    
    // The handler
    private void Ribbon1_Load(object sender, RibbonUIEventArgs e){
        tab1.Label = Convert.ToDouble(Globals.ThisAddIn.Application.Version) <= 14 ? "myTab" : "MYTAB";
    }
