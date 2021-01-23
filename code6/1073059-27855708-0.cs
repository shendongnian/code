    private void btnAdd_Click(object sender, EventArgs e)
    {
        //Define a variable for intNumber and set the initial value.
        int intNumber = 27;
        //Add 1 to the value of intNumber
        intNumber++; // This is shorthand format for intNumber = intNumber + 1
        //Display the new value of intNumber
        MessageBox.Show(string.Format("Value of intNumber + 1 = {0}", intNumber), "Variables");
    }
