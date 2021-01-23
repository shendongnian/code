    public class ButtonWithPathProperty : Button
    {
        public FileInfo PathToOpen { get; private set; }
    
        public ButtonWithPathProperty(FileInfo path) 
        {
             PathToOpen = path;
             this.Click += new EventHandler(this.button_Click);
        }
    
        private void button_Click(object sender, System.EventArgs e)
        {
            var yourPath = this.PathToOpen;
        } 
    }
