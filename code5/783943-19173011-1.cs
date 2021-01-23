        private void button1_Click(object sender, EventArgs e) {
            Task.Factory.StartNew(() =>
                {
                    DataClass dataClass = new DataClass(this.textBox1);
                    Thread.Sleep(5000); // simulate long running task
                    dataClass.TextToPass = "set some text";
                    dataClass.updateTargetControl();
                });
        }
        private class DataClass {
            delegate void updateTextBoxOnUiThreadDelegate();
    
            private TextBox _targetControl= null;
            private updateTextBoxOnUiThreadDelegate _updateDelegate; 
            internal DataClass(TextBox targetControl) {
                _updateDelegate = new updateTextBoxOnUiThreadDelegate(updateOnUiThread);
                _targetControl = targetControl;
            }
            internal string TextToPass = "";
            internal void updateTargetControl() {
                _targetControl.Invoke(_updateDelegate);
            }
            private void updateOnUiThread() {
                _targetControl.Text = this.TextToPass;
            } 
        }
