     public delegate void PassText(string textValue);
    
            public event PassText RaisePassTextEvent;
    
     private void textBox_TextChanged(object sender, EventArgs e)
            {
                if (RaisePassTextEvent != null)
                {
                    RaisePassTextEvent(textBox.Text);
                }
    
            }
