    using System.Globalization;
    
        void btnTwo_Click(object sender, EventArgs e) {
          Double a;
          Double b;
        
          // Let's be generous and accept leading/trailing spaces
          if (!Double.TryParse(textbox1.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out a)) {
            textbox2.Text = "First term is of incorrect format.";
        
            return;
          }
        
          if (!Double.TryParse(textbox2.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out b)) {
            textbox2.Text = "Second term is of incorrect format.";
        
            return;
          }
        
          textbox2.Text = (a + b).ToString(CultureInfo.InvariantCulture);
        }
