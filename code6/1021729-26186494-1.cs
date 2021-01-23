    So like this:
        private void initDataTable(string date)
        {
           employeesTimeDataSet.Tables.Remove(employeeInfoDataTable);
           employeesTimeDataSet = businessLayer.getEmployeesTime(employees, date);
           employeesTimeDataSet.Tables.Add(employeeInfoDataTable); // <-- now it works
           employeesTimeDataTable = businessLayer.buildEmployeesTimeDataTable(employeesTimeDataSet);
        }
