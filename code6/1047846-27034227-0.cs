     if( MessageBox.Show(System.IO.File.ReadAllText(Application.StartupPath + "\\EULA.txt"),"Confirm Eula",MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                   //user accepted Eula
               }
               else
               {
                   // user disagreed
               }
