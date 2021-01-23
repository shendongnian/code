    private void Resultlst_SelectedIndexChanged(object sender, EventArgs e)
    {
        Animal theanimal = (Animal)Resultlst.SelectedItem;  // now works
        EaterTypetxt.Text = theanimal.GetEaterType().ToString();
    }
