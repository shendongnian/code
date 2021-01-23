    OuderDAL Ouder = new OuderDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string naam = User.Identity.Name;
        DAL.TOUD user; 
    if(Ouder.GetCompleteOuder(out user, naam))
    {
        
        /*vullen van de velden met de gegevens voor de ingelogde gebruiker*/
        NaamTxt.Text = user.Naam;
