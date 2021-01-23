     private void DoThings()
     {
      MyFunc(this.Controls);
     }
     private void MyFunc(Control.ControlCollection controls)
     {
          foreach (Control x in this.Controls)
          {
              if (x is NumericTextBox)
              {
                 s = i.ToString() + ", " + ((NumericTextBox)x).Text;
                 Append_to_Template_File(s);
                 i++;
              }
              if (x.HasChildren)
                  MyFunc(x.Controls)
          }
     }
