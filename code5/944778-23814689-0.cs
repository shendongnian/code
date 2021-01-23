    static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                Form1 myStart = new Form1();
                Form2Reservations myLogin = new Form2Reservations();
    
                if (myStart.ShowDialog() == DialogResult.OK)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(myLogin);
                }
                else
                {
                    Application.Exit(); // here was the mistake
                }
            }
