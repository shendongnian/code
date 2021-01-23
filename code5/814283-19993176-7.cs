    /*
     * Mosbrucker_C_PRO_01              Author: Mosbrucker, Cody
     * Creates a class for employee with data members;
     * Employee number, name, date of hire, and monthly salary.
     * ****************************************************/
     namespace EmployeeProgram
     {
       public class employee
        {
          private int employeeNumber;
          private string name;
          private string dateOfHire;
          private int monthlySalary;
    
    	   public employee(int employeeNumber, string name, string dateOfHire, int monthlySalary)
        {
    
            this.employeeNumber = 123;
            this.name = "Cody";
            this.dateOfHire = "01/01/11";
            this.monthlySalary = 2500;
        }
    
        public int EmployeeNumber
        {
            get
            {
                return employeeNumber;
            }
            set
            {
                employeeNumber = value;
            }
        }
    
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    
        public string DateOfHire
        {
            get
            {
                return dateOfHire;
            }
            set
            {
                dateOfHire = value;
            }
        }
    
        public int MonthlySalary
        {
            get
            {
                return monthlySalary;
            }
            set
            {
                monthlySalary = value;
            }
        }
    
        public override string ToString()
        {
            return "Employee Id: " + employeeNumber +
                   "Employee Name: " + name +
                   "Employee Date of Hire: " + dateOfHire +
                   "Employee Monthly Salary: " + monthlySalary;
        }
    
    
    }
    }
