    try
    {
       // other code here
    
    using(var fileOut = new StreamWriter("employeePay.dat", true)
                    {
                        fileOut.Write(txtName.Text);
                        fileOut.Write(",");
                        fileOut.Write(txtNumber.Text);
                        fileOut.Write(",");
                        fileOut.Write(txtHourlyRate.Text);
                        fileOut.Write(",");
                        fileOut.Write(txtHoursWorked.Text);
                        fileOut.Write(",");
                        fileOut.WriteLine(lblGrossPay.Text);
                    }
    }
    catch(...)
    {
       MessageBox();
    }
    
    // any code after the catch will still execute
