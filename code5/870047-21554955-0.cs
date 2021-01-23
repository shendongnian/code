    protected void Page_Load(object sender, EventArgs e)
    {
        If (IsNothing(Session("Time")) {
            Session("Time") = DateTime.Now();
            Hit();
        }
        else {
           If (DateTime.Now - (DateTime)Session("Time")).Minutes > 4) {
               Hit();
               // Then what do you want? Store information that the 5 minutehit has been made so it does not happen again?
           }
        }
    }
