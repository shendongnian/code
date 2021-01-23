    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ClassLibrary;
    using System.Data;
    
    namespace DAL
    {
        public static class CustomerDAL
        {
    	 public static void Insert(Customer p){.......}
    	 public static List<Customer> FillComboBox(){......}
    	 public void Update(Customer oldCustomer, Customer newCustomer){.......}
    	}
    }
    ----------------------------------------------------
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ClassLibrary;
    using System.Data;
    
    namespace BAL
    {
        public class Customer
        {
    	 public int Id {get;set;}
    	 public string Name {get;set;}
    	 .......................
    	 .......................
    	}
    }
    ------------------------------------------------------
    In UI Create a Windows or Web Form and add buttons and textbox and on buttonSave_Click event 
    If(txtName.Text=="")
    {
    MessageBox.Show("Some text", "Some title", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    	txtName.Focus();
    }
    else
    {
    //calling BAL
    var cus=new Customer{
    Name=txtName.Text
    }
    //Calling DAL
    CustomerDAL.Insert(cus);
    MessageBox.Show("Information", "Record saved successfully inti the database.", 
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    	txtName.tex="";
    	
    }
    
    Hope this will help you.
