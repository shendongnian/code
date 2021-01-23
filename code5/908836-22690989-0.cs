            UserControlStandardMacchine uc = null;
            private void tabPageMacchine_Enter(object sender, EventArgs e) 
            {
                if (uc!= null) 
                {
                     uc = new UserControlStandardMacchine (); 
                     uc.Parent = this; 
                     uc.Dock = DockStyle.Fill; 
                     uc.refreshData (); 
                 } 
                 else 
                 {
                     uc.refreshData(); 
                 } 
            }
