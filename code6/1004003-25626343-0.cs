    public int recordsReturned;
    public int recordCount;
    protected void nameOfYourOnSelectedMethod(object sender, ObjectDataSourceStatusEventArgs e)
    {
    // check if this call is from the Select or SelectCount method
    if (e.ExecutingSelectCount) {
      // logic here will be used for setting the label
      recordCount = e.ReturnValue;
      Label.Text = "The grid only shows the first " + recordsReturned.ToString()  + " results of a total of " + recordCount.ToString();
    }
    else {
      // logic here is to get the amount of records returned
      // you just want to save the value here
      recordsReturned = e.ReturnValue.Count();
    }
