        private Task T;
        private void Form1_Load(object sender, EventArgs e)
        {
            // ... make sure your string stuff is setup first ...
            T = Task.Run(delegate() { 
                while (true)
                {
                    // ... code ...
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }    
