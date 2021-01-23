    private void ChangeFloor(Label lift, Button btn)
    {
        int level = Convert.ToInt16(lift.Text);
        int desired = Convert.ToInt16(btn.Tag);
        while( level!=desired )
        {
            Thread.Sleep(3000);  // <--- Pause for 3 seconds...
            if (level > desired)
            {
                timer1.Start();
                lift.Text = (--level).ToString();
            }
            else
            {
                timer1.Start();
                lift.Text = (++level).ToString();
            }
        }
    }
