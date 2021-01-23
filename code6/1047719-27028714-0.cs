    public async void Login()
    {
        try
        {
            MyEmail = listView1.Items[i].SubItems[0].Text;
            MyPassword = listView1.Items[i].SubItems[1].Text;
            MySecurity = listView1.Items[i].SubItems[2].Text;
            var loginDetails = new LoginDetails(MyEmail, MyPassword, MySecurity, Platform.Ps3);
            client[i] = new FutClient();
            var loginResponse = await client[i].LoginAsync(loginDetails);
            MessageBox.Show("Succesful login");
        }
        catch (Exception ex)
        {
            string foutMelding = ex.InnerException.ToString();
            ListViewItem exception = new ListViewItem(time);
            exception.SubItems.Add(foutMelding);
            listView2.Items.Add(exception);
        }
    }
    public void StartLogin()
    {
        for (int i = 0; i < objectsToCreate; i++)
        {
            var _ = Login();
        }
    }
