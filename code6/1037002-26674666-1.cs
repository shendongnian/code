    protected void Page_Load(object sender, EventArgs e)
    {
              switch(MasterPage.hatRolle)
        {
            case 0: b_home.Visible = true;
                    b_kontakte.Visible = true;
                    b_profil.Visible = true;
                    b_reservieren.Visible = true;
                    b_verleihhistorie.Visible = true;
                    b_warenausgang.Visible = true;
                    b_wareneingang.Visible = true;
                    b_neueKunden.Visible = true;
                    break;
            //case 1: .....
            //...........
        }
    }
