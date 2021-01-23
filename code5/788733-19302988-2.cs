    public partial class Form1 : Form
    {
         private MyDBContext context = new MyDBContext(); // whatever your context name is
         private void btnLoadData_Click(object sender, EventArgs e) // when you want to load the data
         {
            var customersQuery = from o in context.Payments
                                 select o;
            dataGridView1.DataSource = new BindingList<Payments>(customersQuery.ToList());
         }
 
         private void btnSaveChanges_Click(object sender, EventArgs e) // when you want to save
         {  
           context.SaveChanges();
         }
    }
