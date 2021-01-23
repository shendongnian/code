    using System.ComponentModel;    
    //...
    public partial class Form1 : Form
    {
        // declare your custom binding list 
        BindingList<CustomItem> myList = null;
        public Form1()
        {
          InitializeComponent();
          // initialize your list.
          myList = new BindingList<CustomItem>();    
          // binding your list to your listbox                 
          listBox1.DataSource = myList;
        }
    
        
        // a simple button to add items, parse your values here
        private void button1_Click(object sender, EventArgs e)
        {
          myList.Add(new CustomItem("Productname",10, 24.99));           
        }
    
    
      }
