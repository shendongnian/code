    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Employee
    {
    struct Employees
    {
        public int Worker_ID;
        public string lastname;
        public string firstname;
        public int phone;
        public double salary;
    }
    public partial class Form1 : Form
    {
        private List<Employees> dataList = new List<Employees>();
    
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void GetData(ref Employees info)
        {
            try
            {
                info.Worker_ID = int.Parse(employeebox.Text);
                info.lastname = lastnamebox.Text;
                info.firstname = firstnamebox.Text;
                info.phone = int.Parse(phonebox.Text);
                info.salary = double.Parse(salarybox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
    
        }       
    
        private void savebt_Click(object sender, EventArgs e)
        {
         Employees save = new Employees();
            GetData(ref save);
            dataList.Add(save);
    
            employeebox.Clear();
            lastnamebox.Clear();
            firstnamebox.Clear();
            phonebox.Clear();
            salarybox.Clear();
    
            employeebox.Focus();
        }
    
        private void employeesbt_Click(object sender, EventArgs e)
        {
            string output;
            employeelistbox.Items.Clear();
            foreach (Employees aSave in dataList)
            {
                output = aSave.Worker_ID + " " + aSave.lastname + aSave.firstname + "Salary :" + aSave.salary;
            employeelistbox.Items.Add(output);
            }
        }
    
    
    }
    } // -> 1 Extra Parenthesis required
