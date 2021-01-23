    public static Int32? Int32TryParseSafe(String text) {
        Int32 value;
        return Int32.TryParse( text, out value ) ? value : null;
    }
    // Usage:
    newGrid.EmployeeID = Int32TryParseSafe( employeeIDTextBox.Text );
