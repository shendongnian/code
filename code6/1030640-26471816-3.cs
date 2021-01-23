    private void button3_Click(object sender, EventArgs e)
    {
        List<string> list = new List<string>();
        for (int j = 0; j < 10; j++)
        {
            for (int k = 0; k < 10; k++)
            {
                if (a[j] == a[k])
                    b = b + 1;
            } //end of for (k)
            list.Add(a[j] + ":" + b);
            b = 0;
        } //end og for (j)
        List<string> result = list.Distinct().ToList();
        listBox2.DataSource = result;
        //listBox2.DataBind(); this is needed if it is asp.net, if it is winforms it is not needed !
    }
