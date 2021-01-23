            [System.Runtime.InteropServices.DllImport("kernel32.dll")]
            private static extern bool AllocConsole();
    
            private void button1_Click(object sender, EventArgs e)
            {
                AllocConsole();
                this.Hide();
                // Just call the console related methods in here
            }
