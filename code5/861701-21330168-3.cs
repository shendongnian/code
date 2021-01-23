    public override void OnLoad(../*cant' remember the parameters*/){
        if(!Page.IsPostBack){
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
