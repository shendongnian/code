    if (!Page.IsPostBack ) {
        int nbr = (int)DB.ExecScal("select count(*) from produit");
        nbr = ((nbr % 12) == 0) ? (nbr / 12) : (int)(nbr / 12) + 1; // number of pages
        ListBxNbrPG.Items.Clear(); //initialisation of dropdownlist
        for (int i = 1; i <= nbr; i++)
        {
            ListBxNbrPG.Items.Add(i.ToString());
            ListBxNbrPG.Items[i - 1].Value = i.ToString();
        }
         if (Request.Params["pg"] != "" )
         {
            label.text=Request.Params["pg"].ToString(); //always it give number 1
         }
    }
