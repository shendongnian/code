            string[] a = new string[100];`
            string word = tb.Text;
            
            WinFormsApp2.Form1 fi = new WinFormsApp2.Form1();
            
            for (int i = 0; i < 100; i++)
            {
                if (word == fi.find[i])
                {
                    MessageBox.Show("FOUNDED");
                }
                
            }
