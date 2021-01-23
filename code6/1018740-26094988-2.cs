     private void myActionMethod(string action)
        {
          
          switch (action)
          {
            case "btnAdd_Click"
                  string newItem = txtItem.Text;
                  lstItems.Items.Add(newItem);
                  int numberOfItems = lstItems.Items.Count;
                  string y = numberOfItems.ToString();
                  txtAantal.Text = y;
                  txtItem.Text = "";
                 break;
         
           case "lstItems_SelectedIndexChanged"
                int Selected = lstItems.SelectedIndex;
                Selected += 1;
                string x = Selected.ToString();
                txtSelected.Text = x;
                break;
    
          case "btnClear_Click"
                int Location = int.Parse(txtRemoveAt.Text);
                Location -= 1;
                lstItems.Items.RemoveAt(Location);
                int numberOfItems = lstItems.Items.Count;
                string y = numberOfItems.ToString();
                txtAantal.Text = y;
                break;
        case "btnRemoveAt_Click"
              int Location = int.Parse(txtRemoveAt.Text);
              Location -= 1;
              lstItems.Items.RemoveAt(Location);
              int numberOfItems = lstItems.Items.Count;
              string y = numberOfItems.ToString();
              txtAantal.Text = y;
              break;
          }
        }
