        private void duplicateTab()
        {
            // Your TabControl Name
            TabPage selectedTab = tabControl1.SelectedTab;
            TabPage newTab = new TabPage();
            foreach (Control ctrl in selectedTab.Controls)
            {
                Control newCtrl = (Control)Activator.CreateInstance(ctrl.GetType());
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(ctrl);
                foreach (PropertyDescriptor proDe in pdc)
                {
                    object val = proDe.GetValue(ctrl);
                    proDe.SetValue(newCtrl, val);
                }
                
                newTab.Text = "New Tab";
                newTab.Controls.Add(newCtrl);
            }
            tabControl1.TabPages.Add(newTab);
        }
