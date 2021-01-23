    using System.Windows;
    
    namespace dp
    {
        public class ClassA : DependencyObject
        {
            public string TestProperty
            {
                get { return (string)GetValue(TestPropertyProperty); }
                set { SetValue(TestPropertyProperty, value); }
            }
            public static readonly DependencyProperty TestPropertyProperty =
                DependencyProperty.Register("TestProperty", typeof(string), typeof(ClassA), new PropertyMetadata(null, new PropertyChangedCallback( (s, e)=>
                    {
                    })));
        }
    
        public class ClassB : ClassA
        {
            static ClassB()
            {
                TestPropertyProperty.AddOwner(typeof(ClassB), new PropertyMetadata((s, e) =>
                    {
                    }));
            }    
        }
    
        public partial class MainWindow : Window
        {
            public ClassB TestClassB
            {
                get { return (ClassB)GetValue(TestClassBProperty); }
                set { SetValue(TestClassBProperty, value); }
            }        
            public static readonly DependencyProperty TestClassBProperty =
                DependencyProperty.Register("TestClassB", typeof(ClassB), typeof(MainWindow), new PropertyMetadata(null));
    
    
            public MainWindow()
            {
                InitializeComponent();
                TestClassB = new ClassB();
                TestClassB.TestProperty = "test";
            }
        }
    }
