     private void TopSeat_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TableModel.ColorChange(1, ref TopSeat);
            }
        }
