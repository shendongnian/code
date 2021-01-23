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
           var temItem= sender as DropDownList;  // if you are talking about DropDownList
            TextBoxFornamn.Text = temItem.SelectedItem.Text;
        }
}
