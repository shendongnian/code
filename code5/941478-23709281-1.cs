    int cnt = 0;
    for (int i = 1; i <= 90; i++)
    {
        cnt++;
        if (cnt == 10)
        {
            comboBox1.Items.Add("Reduced by: " + i.ToString());
            cnt = 0; //Reset  
        }
    }
