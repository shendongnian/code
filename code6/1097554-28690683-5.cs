    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var p1 = new Person() {FirstName = "Johny", LastName = "Bravo"};
                var p2 = new Person() {FirstName = "Alex", LastName = "Flo"};
                var list = new List<ItemWrapper<Person>>
                {
                    new ItemWrapper<Person>(p1, p => p.FirstName),
                    new ItemWrapper<Person>(p2, p => p.FirstName)
                };
                var bs = new BindingSource(list, "Item");
                this.listBox1.DataSource = bs;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var person = this.listBox1.SelectedValue as Person;
            }
        }
    }
