    try {
      DateTime dt = new DateTime(int.Parse(txtYear.Text),
                                 int.Parse(txtMonth.Text),
                                 int.Parse(txtDate.Text));
       lblOutput.Text = dt.ToString(); //Not sure why we'd do this, but whatever
    } catch (ArgumentOutOfRangeException) {
       lblOutput.Text = "Invalid Date Time!!!";
    }
