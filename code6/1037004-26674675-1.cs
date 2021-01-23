     protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                b_home.Visible = true;
                b_kontakte.Visible = true;
                b_profil.Visible = false;
                b_reservieren.Visible = false;
                b_verleihhistorie.Visible = false;
                b_warenausgang.Visible = false;
                b_wareneingang.Visible = false;
                b_neueKunden.Visible = false;
            }
        }
