    List<int> selectedIndices = new List<int>();
    //SelectedIndexChanged event handler for your listBox1
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
       if (listBox1.SelectedIndex > -1){                
          selectedIndices.AddRange(listBox1.SelectedIndices.OfType<int>()
                                           .Except(selectedIndices));                                                               
          selectedIndices.RemoveRange(0, selectedIndices.Count - listBox1.SelectedItems.Count); 
       }
    }
    //Now all the SelectedIndices (in order) are saved in selectedIndices;
    //Here is the code to get the SelectedItems in order from it easily
    var selectedItems = selectedIndices.Select(i => listBox1.Items[i]);
