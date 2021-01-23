    List <CheckBox> CheckBoxes=new List <CheckBox> ();
     
    foreach (var box in Checklist)
    {
     CheckBox chk = new CheckBox();
     chk.Left = 50;
     chk.Text = box.Text;
     chk.Name = box.NAme;
     CheckBoxes.Add(chk);
    }
