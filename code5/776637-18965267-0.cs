    // Build ArrayList
    ArrayList al = new ArrayList();
    al.Add(1);
    al.Add(1);
    al.Add(2);
    al.Add(2);
    al.Add(3);
    al.Add(4);
    al.Add(4);
    al.Add(4);
    // Create List from ArrayList
    List<object> oList = new List<object>(al.ToArray());
    // Declare holder to distinct values
    List<object> distinctValues = new List<object>();
    // Get distinct values
    oList.ForEach(delegate(object o) {
        if (!distinctValues.Contains(o)) {
            distinctValues.Add(o);
        }
    });
    // Copy original list as a list with duplicates
    List<object> duplicateValues = new List<object>(oList);
    // Remove the first instance of each distinct value
    // leaving all duplicates
    distinctValues.ForEach(delegate(object o){
        duplicateValues.Remove(o);
    });
    // Display distinct values
    foreach (object o in distinctValues) {
        MessageBox.Show(o.ToString(), "Distinct");
    }
    // Display duplicate values
    foreach (object o in duplicateValues) { 
        MessageBox.Show(o.ToString(), "Duplicate");
    }
