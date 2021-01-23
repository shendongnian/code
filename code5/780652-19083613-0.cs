    for (int i = 0; i < Application.OpenForms.Count; i++ )
    {
        Form f = Application.OpenForms[i];
        if (f.Text != ChatReader["Sender"].ToString())
        {
            //...
            chat.Show();
            chat.BringToFront();
        }
        // ...
    }
