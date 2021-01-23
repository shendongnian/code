    public IEValue IE_Value
    {
        get
        {
            return new IEValue() {
                IsEmrino = txtIsEmriNo.Text,
                Nevi = txtNevi.Text,
                BrutKg = txtBrutKg.Text,
                NetKg = txtNetKg.Text
            };
        }
        set
        {
            txtIsEmriNo.Text = value.IsEmrino;
            txtNevi.Text = value.Nevi;
            txtBrutKg.Text = value.BrutKg;
            txtNetKg.Text = value.NetKg;
        }
    }
