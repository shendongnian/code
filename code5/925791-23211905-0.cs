    private void button119_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeColor(sender as Control);
        }
    private void button119_MouseHover(object sender, EventArgs e)
        {
            if (Control.MouseButtons == System.Windows.Forms.MouseButtons.Left) 
            { 
                ChangeColor(sender as Control);
            }
        }
    private void ChangeColor(Control ctrl)
        {
            switch (ctrl.BackColor.Name)
            {
            case "Aquamarine":
                ctrl.BackColor = Color.Yellow;
                break;
            case "Yellow":
                ctrl.BackColor = Color.CornflowerBlue;
                break;
            case "CornflowerBlue":
                ctrl.BackColor = Color.Gainsboro;
                break;
            default:
                ctrl.BackColor = Color.Aquamarine;
                break;
            }
        }
