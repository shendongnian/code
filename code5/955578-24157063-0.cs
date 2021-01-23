    // Setting up the startup event
    private void InternalStartup(){
        this.Startup += new System.EventHandler(ThisAddIn_Startup);
    }
    // The event handler
    private void ThisAddIn_Startup(object sender, System.EventArgs e){
        Globals.Ribbons.Ribbon1.tab1.Label = Convert.ToDouble(Globals.ThisAddIn.Application.Version) <= 14 ? "myTab" : "MYTAB";
    }
