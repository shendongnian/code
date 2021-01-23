    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var test = LoadCategoryData();
            this.Controls.Add(test);
        }
        public ComboBox LoadCategoryData()
        {
            ComboBox cbx = new ComboBox();
            CategoryView viewItem = new CategoryView();
            viewItem.Name = "Select Category";
            IList<CategoryView> categories = new List<CategoryView>() { new CategoryView() { Name = "Item1", Id = 1 } };
            categories.Insert(0, viewItem);
            cbx.DataSource = categories;
            cbx.DisplayMember = "Name";
            cbx.ValueMember = "Id";
            return cbx;
        }
    }
    public class CategoryView
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
