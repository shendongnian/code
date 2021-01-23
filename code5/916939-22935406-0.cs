    foreach (Control c in MyForm.Controls) 
    {
       UpdateColorControls(c);
    }
    public void UpdateColorControls(Control myControl)
    {
       myControl.BackColor = Colors.Black;
       myControl.ForeColor = Colors.White;
       foreach (Control subC in myControl.Controls) 
       {
           UpdateColorControls(subC);
       } 
    }
