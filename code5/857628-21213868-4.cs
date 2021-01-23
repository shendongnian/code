    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace TreeViewSelectTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                RootNode = new TreeNodeVm("Root", new[]
                {
                    new TreeNodeVm("A", new [] {
                        new TreeNodeVm("A1", new TreeNodeVm[0]),
                        new TreeNodeVm("A2", new TreeNodeVm[0]),
                        new TreeNodeVm("A3", new TreeNodeVm[0])
                    }),
                    new TreeNodeVm("B", new [] {
                        new TreeNodeVm("B1", new TreeNodeVm[0])
                    })
                });
    
                InitializeComponent();
                this.DataContext = this;
            }
    
            public TreeNodeVm RootNode { get; private set; }
    
            private void btSelectB1_Click(object sender, RoutedEventArgs e)
            {
                RootNode.Children[1].Children[0].Select();
            }
        }
    }
