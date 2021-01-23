    private async void button1_Click(object sender, EventArgs e)
    {
        lblSearchStatus.Text = "searching for First Name--";
        Task task1 = Task.Run(() => FetchFirstNames());
        await task1;
        lblSearchStatus.Text = lblSearchStatus.Text + " searching for Last Name-";
        Task task2 = Task.Run(() => FetchLastNames());
        await task2;
        lblSearchStatus.Text = lblSearchStatus.Text + " ---- All Done ----";
    }
    private async Task FetchFirstNames()
    {
        string str1 = "";
        lblSearchStatus.Text = lblSearchStatus.Text + " Start first name -";
        for (int i = 0; i < 100000000; i++)
        {
            str1 = i.ToString();
        }
        lblSearchStatus.Text = lblSearchStatus.Text + " first name: i=" + str1;
    }
    private async Task FetchLastNames()
    {
        string str1 = "";
        lblSearchStatus.Text = lblSearchStatus.Text + " Start Last name -";
        for (int i = 0; i < 100000000; i++)
        {
            str1 = i.ToString();
        }
        lblSearchStatus.Text = lblSearchStatus.Text + " last name: i=" + str1;
    }
