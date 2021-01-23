    // addStudent ...
    var txtstdname = new Dictionary<string, Student>();
     // ... 
    txtstdname.Add(txtsid.Text, new Student(txtsid.Text,txtsname.Text))
   
    // searchStudent ...
    Student element = null;
    if (txtstdname.TryGetValue(out element))
    {
        txtstdname.Text = element.Name();
    }
