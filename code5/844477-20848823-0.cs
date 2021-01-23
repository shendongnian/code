    if (string.IsNullOrEmpty(employeeIDTextBox.Text) && (string.IsNullOrEmpty(JobIDTextBox.Text)))
    {
        MessageBox.Show("Please enter a EmployeeID or JobID.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        Return;
     }
