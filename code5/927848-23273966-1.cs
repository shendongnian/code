    private void save_Click(object sender, EventArgs e)
    {
        int civil_caseI;
        if (!int.TryParse(civil_case.Text, out civil_caseI))
        {
            MessageBox.Show("Enter Number Only on CIVIL CASE");
            return; //add that - early return
        }
        string areaI = area.Text;
        if (string.IsNullOrEmpty(areaI.Trim()))
        {
            MessageBox.Show("Area Field must not be Empty");
            return;
        }
        string addressI = address.Text;
        if (string.IsNullOrEmpty(addressI.Trim())) //or addressI.Trim().Length <= 0
        {
            MessageBox.Show("Address Field must not be Empty");
            return;
        }
        //HERE WILL BE THE QUERY TO INSERT THE DATA AFTER THE FORM IS VALIDATED.
    }
