    public void Page_Init(object sender, EventArgs e){
        CreateDynamicControls();
    }
    
    public void CreateDynamicControls(){
        HtmlGenericControl span = new HtmlGenericControl("span");
        DropDownList ddlList = new DropDownList();
        TextBox txtValeur = new TextBox();
        Button btnAdd = new Button();
        ListItem item1 = new ListItem("No. Projet", "no");
        ListItem item2 = new ListItem("Désignation Projet", "desi");
        ListItem item3 = new ListItem("Chef de Projets", "chef");
    
        span.Style.Add(HtmlTextWriterStyle.Color, "Black");
        span.InnerText = "Filtre " + (i + 1).ToString() + " : ";
    
        ddlList.ID = "ddlFiltreProjets" + (i + 1).ToString();
        ddlList.Items.Add(item1);
        ddlList.Items.Add(item2);
        ddlList.Items.Add(item3);
    
        txtValeur.ID = "txtValeurFiltreProjets" + (i + 1).ToString();
        txtValeur.ForeColor = System.Drawing.Color.Black;
    
        btnAdd = btnAddFiltre1;
    
        divChampsFiltrageProjetsTest.Controls.Add(span);
        divChampsFiltrageProjetsTest.Controls.Add(ddlList);
        divChampsFiltrageProjetsTest.Controls.Add(txtValeur);
        divChampsFiltrageProjetsTest.Controls.Add(btnAdd);
    }
