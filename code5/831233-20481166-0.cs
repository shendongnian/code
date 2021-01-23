    namespace WindowsFormsApplication1
    {
    
        public class Product
        {
            String name;
    
            public Product(String name)
            {
                this.name = name;
            }
    
            public override string ToString()
            {
                return name;
            }
        }
    
        public partial class Form1 : Form
        {
            IList<Product> list = new List<Product>() { new Product("abc"), new Product("def") };
    
            public Form1()
            {
                InitializeComponent();
                listBox1.DataSource = list;
            }
   
        }
    }
