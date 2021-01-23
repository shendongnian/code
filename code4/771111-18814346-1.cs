        public class GuiClass
        {
            public void foo() {
        
                var reader = new SerialReader();
                reader.Callback = UpdateStatusBar;
                
            }
            public void UpdateStatusBar(string message) {
                statusBar.Text = message;
            }
        }
