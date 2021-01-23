     private Person aktuellPerson;
    protected void Page_Load(object sender, EventArgs e)
    {
        ListBoxPersoner.DataSource = Databasfunktioner.getPersoner();
        ListBoxPersoner.DataValueField="PersonID";
        ListBoxPersoner.DataTextField="Fornamn";
        ListBoxPersoner.DataBind();
    }
        protected void ListBoxPersoner_SelectedIndexChanged(object sender, EventArgs )
       {
           
            TextBoxFornamn.Text = ListBoxPersoner.SelectedItem.Text;
        }
}
