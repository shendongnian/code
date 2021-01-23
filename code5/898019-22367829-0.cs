    List<CheckBox> groupOfCheckBoxes = new List<CheckBox>();
    void InitFunction() {
        groupOfCheckBoxes.Add(checkbox1);
        groupOfCheckBoxes.Add(checkbox2);
        groupOfCheckBoxes.Add(checkbox3);
        foreach (CheckBox cb in groupOfCheckBoxes)
         cb.Click += checkbox_Click
    }
    void checkbox_Click(object sender, EventArgs e) 
    {
     foreach (CheckBox cb in groupOfCheckBoxes) {
      cb.IsChecked = cb == sender;
     }
    }
