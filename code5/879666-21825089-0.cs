       if (listBox1.SelectedItem != null)
       {
              if(!string.IsNullOrEmpty(listBox1.SelectedValue))
              {
                    _AttName.Add(listBox1.SelectedValue.ToString());
                    listBox1.SetSelected(listBox1.SelectedIndex, false);
              }
       }
