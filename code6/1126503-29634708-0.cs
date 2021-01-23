    var control = this.Controls.Find(strLabel, true); //pass "lbl" + x + y;
    if(control != null && control.OfType<Label>.Any())
    {
       //label found
       Label label = control.First() as Label;
       label.BackColor = System.Drawing.Color.Green;
    }
