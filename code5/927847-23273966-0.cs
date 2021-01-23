    private void save_Click(object sender, EventArgs e)
    {
        int civil_caseI;
        if (!int.TryParse(civil_case.Text, out civil_caseI))
        {
            MessageBox.Show("Enter Number Only on CIVIL CASE");
            return; //add that - early return
        }
        string areaI = area.Text;
        if (string.IsNullOrWhiteSpace(areaI))
        {
            MessageBox.Show("Area Field must not be Empty");
            return; //add that - early return
        }
        string addressI = address.Text;
        if (string.IsNullOrWhiteSpace(addressI))
        {
            MessageBox.Show("Address Field must not be Empty");
            return; //add that - early return
        }
        //HERE WILL BE THE QUERY TO INSERT THE DATA AFTER THE FORM IS VALIDATED.
    }
