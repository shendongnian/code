     private void tabControl1_Selected(object sender, TabControlEventArgs e) 
     {
         switch(e.TabPageIndex)
         {
             case 0:
                richTextBox.Text = comboBox1.Text;            
                break;
             // so on for the other page and combos
         }
     }
