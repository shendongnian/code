    private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        frmProperties editProperties = new frmProperties();
        editProperties.ShowDialog();
        Employee person = new   Employee ();
	person.EmployeeFirstName = lstBoxEmployees.Items[lstBoxEmployees.SelectedIndex];
        editProperties.TextFirstName = person.EmployeeFirstName;
    }
