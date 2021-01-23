    private void btnHome_Click(object sender, EventArgs e)
    {
        if (CanCurrentViewClose())
        {
            ViewHome v = new ViewHome();
            // Further initialization of v here
            SwitchView(v);
        }
        else
        {
            MessageBox.Show("Current View can not close!");
        }
    }
