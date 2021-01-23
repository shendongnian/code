     protected void Page_Load(object sender, EventArgs e) {
            if (!Page.IsPostBack) {
                PopulatePhysician();
                ASPopulateLocation();
                ASPopulateSpecialty();
            }
    
            if (Session["LocationText"] != null && Session["SpecialtyText"] != null && Session["GenderText"] != null) {
    
                this.OnBtnClick();
            }
        }
