        private void fudafrm_Load(object sender, EventArgs e)
        {
            this.Hide(); // not necessary from the Load() event
            loginfrm f2 = new loginfrm();
            if (f2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                switch(f2.UserType)
                {
                    case loginfrm.UserTypes.admin:
                        // remove nothing
                        break;
                    case loginfrm.UserTypes.salesman:
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage3);
                        break;
                    case loginfrm.UserTypes.accountant:
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage2);
                        tabControl1.TabPages.Remove(tabPage5);
                        break;
                    case loginfrm.UserTypes.stockmanager:
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Remove(tabPage4);
                        tabControl1.TabPages.Remove(tabPage7);
                        tabControl1.TabPages.Remove(tabPage8);
                        break;
                }
                
            }
            else
            {
                Application.Exit(); // ?
            }
        }
