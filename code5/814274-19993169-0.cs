    public class employee
    {
        private int employeeNumber;
        private string name;
        private string dateOfHire;
        private int monthlySalary;
        public employee(int employeeNumber, string name, string dateOfHire, int monthlySalary)
        {
            this.employeeNumber = 123;//because you have naming collissions you need to use `this`
            this.name = "Cody";
            this.dateOfHire = "01 / 01 / 11";
            this.monthlySalary = 2500;
        }
        public override string ToString()
        {
            return "Employee Id: " + employeeNumber +
                   "Employee Name: " + name +
                   "Employee Date of Hire: " + dateOfHire +
                   "Employee Monthly Salary: " + monthlySalary;
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
