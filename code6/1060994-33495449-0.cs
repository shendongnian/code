          private void dgv1_MouseClick(object sender, MouseEventArgs e)
           {
               if (e.Button == MouseButtons.Right)
                {
                   ContextMenuStrip m = new ContextMenuStrip();
                   m.Items.Add("Add");
                   m.Items.Add("Delete");
                   m.Show(dgv1, new Point(e.X, e.Y));
                   m.ItemClicked += new ToolStripItemClickedEventHandler(Item_Click);
           }
         }
         private void Item_Click(object sender, ToolStripItemClickedEventArgs e)
         {
            if (e.ClickedItem.Text == "Delete")
            {
                //Codes Here
            }
            else
            {
               //Codes Here
            }
         }
