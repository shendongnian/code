      foreach (var control in controls)
      {
          if (control is RadioButton || control is CheckBox)
          {
                 control.Width = panelWidth - 10;
                 Font fontUsed = control.Font;
                 using (Graphics g = control.CreateGraphics())
                 {
                   SizeF size = g.MeasureString(control.Text, fontUsed, control.Width);
                  control.Height = (int)Math.Ceiling(size.Height * 1.25);
                }
           }
      }
