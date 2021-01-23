        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           string curItem = listBox1.SelectedItem.ToString();
           //clear all items in listbox2 
           listBox2.Items.Clear();
           //Add SelectedItem's related Person in listbox2
           foreach(Person pers in listofPers)
           {
              if(pers.OrggName == curItem)
              {
               //Add this person in listbox2
                listbox2.Items.Add(pers.FName);
              } 
           }
        }
