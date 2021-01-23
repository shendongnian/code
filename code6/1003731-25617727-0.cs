    private void txtCCA_TextChanged(object sender, EventArgs e)
    {
        sumNumbers()
    }
    private void sumNumbers()
    {
        int.TryParse(txtGTC.Text, out n1);
        int.TryParse(txtPF.Text, out n2);
        int.TryParse(txtbasicsalery.Text, out n3);
        int.TryParse(txthoserent.Text, out n4);
        int.TryParse(txtlicrent.Text, out n5);
        int.TryParse(txtDA.Text, out n6);
        int.TryParse(txtCCA.Text, out n7);
        grossalery = n1 + n2 + n3 + n4 + n5 + n6 + n7;
        txtgrosssalery.Text = Convert.ToString(grossalery);
    }
