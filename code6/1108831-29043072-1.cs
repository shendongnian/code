    public partial class MainWindow : Window
    {   
        // Inner Classes 
       
        public class Dog
        {
            private string name;
            public string Name {
               get{ return this.name };
               set{ this.name = value}'
            }
            
            private int length;
            public int Length {
               get{ return this.length };
               set{ this.length = value}'
            }
            
            public Dog( string _name )
            {
                this.name = _name;
            }
        }
    
        // Properties
        
        // For storing dogs
        private Dicionary<string, Dog> Dogs;
    
    
        // Methods
    
        public MainWindow()
        {
            InitializeComponent();
            
            // New dictionary of dogs
            Dogs = new Dictionary<string, Dog>();
    
            // adding Dogs objects
            Dogs.add("maxwell", new Dog("Maxwell)); 
            Dogs.add("fred", new Dog("Fred"));
    
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabelName.Content = Dogs["maxwell"].Name;
            LabelLength.Content = Dogs["maxwell"].Length;
        }
    }
