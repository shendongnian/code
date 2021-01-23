    UserPrincipal []user_all = search.FindAll();
    int max = user_all.length;
    progressBar1.Maximum = max;
    progressBar1.Step = 1;
    foreach (UserPrincipal user in user_all)
    {
        if (user.IsAccountLockedOut())
        {
            LB1.Items.Add(user.SamAccountName.ToString());
        }
        progressBar1.PerformStep();
    }
