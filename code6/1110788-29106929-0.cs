    for (int i = 1; i <= 100; i++)
    {
        var buttonName = string.Format("button{0}", i);
        var buttonControl = Controls.Find(buttonName, true).FirstOrDefault();
        if (buttonControl != null)
        {
            buttonControl.BackColor = Color.Red;
        }
    }
