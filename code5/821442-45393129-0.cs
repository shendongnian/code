      private void richTextBox2_MouseUp(object sender, MouseEventArgs e)
       {
         if (e.Button == System.Windows.Forms.MouseButtons.Right)
           {   //click event
               //MessageBox.Show("you got it!");
               ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
               MenuItem menuItem = new MenuItem("Cut");
               menuItem.Click += new EventHandler(CutAction);
               contextMenu.MenuItems.Add(menuItem);
               menuItem = new MenuItem("Copy");
               menuItem.Click += new EventHandler(CopyAction);
               contextMenu.MenuItems.Add(menuItem);
               menuItem = new MenuItem("Paste");
               menuItem.Click += new EventHandler(PasteAction);
               contextMenu.MenuItems.Add(menuItem);
               richTextBox2.ContextMenu = contextMenu;
    }
  } 
        void CutAction(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        void CopyAction(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        void PasteAction(object sender, EventArgs e)
        {`
            richTextBox1.Paste();
        }
