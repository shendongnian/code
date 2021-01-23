    //method for all tab pages 
    private void AllTabPages()
    {
          foreach (TabPage pg in tcMainWindow.TabPages)          
              FillControls(pg);    
    }
    
    //method for individual tab page
    private void FillControls(TabPage pg)
    {
         foreach (Control c in pg.Controls)
         {
               if (c is ListView)
               {
                   //do something
                   ListView lv = c as ListView;
                   lv.Items.Add("abc");
                   lv.Items.Add("def");
                }
                else if (c is TextBox)
                {
                   //do something
                   c.Text = "Add Some Text";
                }
          }
    }
