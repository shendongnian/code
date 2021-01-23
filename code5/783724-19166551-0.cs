      public partial class Form1 : Form
      {
         public Form1()
         {
            InitializeComponent();
            CustomerCollection cc = new CustomerCollection();
            cc.Customers.AddRange(new Customer[] {new Customer("1", "Adam"), new Customer("2", "Bob")});
            ComboBox ComboBox1 = new ComboBox()
               {Name = "ComboBox1", ValueMember = "ID", DisplayMember = "Name"};
            Controls.Add(ComboBox1);
            ComboBox1.DataSource = cc;
         }
      }
      public class Customer
      {
         public String ID { get; private set; }
         public String Name { get; private set; }
         public Customer(String id, String name)
         {
            ID = id;
            Name = name;
         }
      }
      class CustomerCollection : IListSource
      {
         public List<Customer> Customers { get; private set; }
         public CustomerCollection()
         {
            Customers = new List<Customer>();
         }
         public bool ContainsListCollection
         {
            get { return true; }
         }
         public System.Collections.IList GetList()
         {
            return Customers;
         }
      }
