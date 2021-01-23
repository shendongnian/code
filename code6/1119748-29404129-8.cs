    private void Resultlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        Animal theanimal = (Animal)Resultlst.SelectedItem;
        EaterTypetxt.Text = theanimal.GetEaterType().ToString();
    }
