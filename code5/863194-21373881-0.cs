    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
            if (e.KeyCode == Keys.Tab)
            {
                switch (count)
                {
                    case 0:
                        this.ActiveControl = uc1TextBox;
                        count++;
                        break;
                    case 1:
                        this.ActiveControl = uc2TextBox;
                        count++
                        break;
                   // and so on...
                }
            }
    }
