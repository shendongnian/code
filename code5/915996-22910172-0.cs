    private void button1_Click(object sender, EventArgs e)
    {
        if (menuHidden)
        {
            menu.BringToFront();
            for (int i = 0; i < menu.Size.Width; i++)
            {
                menu.Location = new Point(menu.Location.X + 1, 0);
                System.Threading.Thread.Sleep(Convert.ToInt32(textBox1.Text));
                Refresh(); // <-----------------------
            }
        }
        else
        {
            for (int i = 0; i < menu.Size.Width; i++)
            {
                menu.Location = new Point(menu.Location.X - 1, 0);
                System.Threading.Thread.Sleep(Convert.ToInt32(textBox1.Text));
                Refresh(); // <-----------------------
            }
        }
        menuHidden = !menuHidden;
    }
