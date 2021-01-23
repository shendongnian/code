    if (day > 30)
    {
        if (MessageBox.Show("Trial expired. Visit site to purchase license?",
            "Trial Expired!", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            Process.Start("http://www.yourwebsite.com");
        }
        Environment.Exit(0);
    }
