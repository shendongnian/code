    private void button1_Click(object sender, EventArgs e)
    {
        button1.Enabled = false;
        var t = new System.Threading.Tasks.Task(Switcher);
        t.Start();
    }
    private void Switcher()
    {
        int status = 0;
        while (true)
        {
            switch (status)
            {
            case 0:
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = false;
                status = 1;
                break;
            case 1:
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                status = 2;
                break;
            case 2:
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                status = 0;
                break;
            }
            System.Threading.Thread.Sleep(200);
        }
    }
