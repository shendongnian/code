        protected void tabClick(object sender, RadTabStripEventArgs e)
        {
        if (e.Tab.SelectedIndex == 0)
        {
               UserControl1.Tab1UpdatePanel.Update();
        }
        else
        {
               UserControl2.Tab2UpdatePanel.Update();
        }
        }
