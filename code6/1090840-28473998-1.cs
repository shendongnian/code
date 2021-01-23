    static var OldValue;
    private void NumericUpDown1_MouseClick(Object sender, EventArgs e) {
    
       if (NumericUpDown1.Value>OldValue)
          {
             ///value increased, handle accordingly
          }
        else if (NumericUpDown1.Value<OldValue)
          {
            ///value decreased, handle accordingly
          }
        else
          {
            return;
          }
     OldValue=NumericUpDown1.Value;
    }
