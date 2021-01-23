    public partial class Form1 : Form
    {
        private BindingList<Test> list;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.list = new BindingList<Test>
            {
                new Test(1,"Entry"),
                new Test(2,"Another Entry")
            };
            dataGridView1.DataSource = new BindingSource(list,null);
            list.ListChanged += list_ListChanged;
            list.Add(new Test(3, "After Binding"));
        }
        void list_ListChanged(object sender, ListChangedEventArgs e)
        {
            CountOfLoadedItemsLabel.Text = string.Format("Items: {0}", list.Count);
        }
    }
    public class Test 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Test(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
