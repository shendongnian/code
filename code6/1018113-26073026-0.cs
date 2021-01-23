     private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                if (e.Button !=MouseButtons.Right)
                {
    
                Panel pnl = sender as Panel;
                if (pnl != null)
                    pnl.DoDragDrop(pnl.BackColor, DragDropEffects.Move);
                }
            }
 
