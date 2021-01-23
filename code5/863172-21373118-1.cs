      namespace WK4
        {
        public partial class MainForm : Form
        {
    Display myDisplay;
            public MainForm()
            {
                InitializeComponent();
        
            }
        
            //Method to clear form input boxes
            private void ClearForm()
            {
                EmployeeNameTextBox.Text = "";
                EmployeeBirthDateTextBox.Text = "";
                EmployeeDeptTextBox.Text = "";
                EmployeeHireDateTextBox.Text = "";
                EmployeeSalaryTextBox.Text = "";
                FooterLabel.Text = "";
            }
        
            //Method to check for blank input on textboxes
            private void CheckForms(ref bool error)            
            {
        
                if (EmployeeNameTextBox.Text == "" || EmployeeBirthDateTextBox.Text == "")
                {
                    MessageBox.Show("Please do not leave any fields blank");
                    error = true;
                }
        
                else if (EmployeeDeptTextBox.Text == "" || EmployeeHireDateTextBox.Text == "")
                {
                    MessageBox.Show("Please do not leave any fields blank");
                    error = true;
                }
        
                else if (EmployeeSalaryTextBox.Text == "")
                {
                    MessageBox.Show("Please do not leave any fields blank");
                    error = true;
                }
                else
                    error = false;
            } 
        
            private void addEmployee(Employee newEmployee)
            {
                //Get data from textboxes and use set methods in employee class
                newEmployee.Name = EmployeeNameTextBox.Text;
                newEmployee.BirthDate = EmployeeBirthDateTextBox.Text;
                newEmployee.Dept = EmployeeDeptTextBox.Text;
                newEmployee.HireDate = EmployeeHireDateTextBox.Text;
                newEmployee.Salary = EmployeeSalaryTextBox.Text;
        
            }
        
            private void AddButton_Click(object sender, EventArgs e)
            {
        
                //New list for employee class objects - employeelist
                List<Employee> employeeList = new List<Employee>();
        
                //Create new instance of Employee class - newEmployee
                Employee newEmployee = new Employee();
        
                bool errorCheck = false;
                CheckForms(ref errorCheck);
        
                if (!errorCheck)
                {
                    //Gather input from text boxes and pass newEmployee object
                    addEmployee(newEmployee);
        
                    //Add object to employeeList
                    employeeList.Add(newEmployee);
        
        
                    Display myDisplay = new Display();
                    myDisplay.OutputListBox.Items.Add(" Bob");
        
                        //" " + newEmployee.BirthDate + " " + 
                        //newEmployee.Dept + " " + newEmployee.HireDate + " " + newEmployee.Salary);
        
                    //Clear Form after adding data
                    ClearForm();
        
                    //Print footer employee saved info
                    FooterLabel.Text = ("Employee " + newEmployee.Name + " saved.");
                }  
            }
        
            //Exit the form/program
            private void ExitButton_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        
            //Method to clear the form and reset focus
            private void ClearButton_Click(object sender, EventArgs e)
            {
                ClearForm();
                EmployeeNameTextBox.Focus();
            }
        
            private void ShowDataButton_Click(object sender, EventArgs e)
            {
        
               
                myDisplay.ShowDialog();
        
            }
        
            private void MainForm_Load(object sender, EventArgs e)
            {
         myDisplay = new Display();
            }
        }
        } 
