        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace garbage
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                SomeCommand = new RelayCommand(SomeCommandExecute, CanExecute);
            }
    
            private ICommand someCommand;
            public ICommand SomeCommand
            {
                get
                {
                    return someCommand;
                }
                set
                {
                    someCommand = value;
                }
            }
    
            public void SomeCommandExecute(object something)
            {
                MessageBox.Show("Success");
            }
    
            private bool CanExecute(object thing)
            { return true; }
    
        }
    }
