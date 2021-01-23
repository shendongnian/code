    var checkedRadio = new []{groupBox1, groupBox2}
                       .SelectMany(g=>g.Controls.OfType<RadioButton>()
                                                .FirstOrDefault(r=>r.Checked))
    //print name
    foreach(var c in checkedRadio)
       System.Diagnostics.Debug.Print(c.Name);
