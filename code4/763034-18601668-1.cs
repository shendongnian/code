       private void listBox1.SelectedIndexChanged(object sender,EventArgs e)
        {
         string item=listBox1.SelectedItem.ToString();
         int index=item.LastIndexOf('.');
         if(index>=0)//It's a valid file
          {
           string extension=item.Substring(index+1,item.Length-index-1);
           if(extension=="folder")
           {
            MessageBox.Show("Yes it's a .folder");
           }
          }
         else if(index==-1)//Not a valid file
          {
            MessageBox.Show("The selected file is invalid.");
          }
        }
