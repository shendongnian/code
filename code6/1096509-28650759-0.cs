    bool flag = false;
    private void pb_target_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            Console.WriteLine("pb_target_MouseDown RIGHT");
            flag = true;
        }
        else flag = false;
    }
    private void pb_target_MouseClick(object sender, MouseEventArgs e)
    {
        if (flag) { flag = false; return; }
        Console.WriteLine("pb_target_MouseClick");
    }
