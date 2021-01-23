    using System.Globalization;
    
        void btnTwo_Click(object sender, EventArgs e) {
          Double a;
          Double b;
        
          if (!Double.TryParse(textbox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out a)) {
            textbox2.Text = "First term is of incorrect format.";
        
            return;
          }
        
          if (!Double.TryParse(textbox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out b)) {
            textbox2.Text = "Second term is of incorrect format.";
        
            return;
          }
        
          textbox2.Text = (a + b).ToString(CultureInfo.InvariantCulture);
        }
