    class InfinityForm : Form {
        
        private FlowLayoutPanel _panel;
        
        public InfinityForm() {
            
            _panel = new FlowLayoutPanel();
            this.Controls.Add( _panel );
            _panel.Dock = Dock.Fill;
        }
        
        public override void OnLoad(Object sender, EventArgs e) {
            
            for(int i = 0; i < 100; i++) {
                
                NumericUpDown editor = new NumericUpDown();
                editor.Controls.Add( editor );
            }
        }
    }
