          int number;
          bool result = Int32.TryParse(employeeIDTextBox.Text, out number);
          if (result)
          {
             newGrid.EmployeeID=number;       
          }
          else
          {
          //whatever you want to do for bad values
          newGrid.EmployeeID=0;
          }
