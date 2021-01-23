    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                List<ComboBoxItem> list = new List<ComboBoxItem>();
                ComboBoxItem item;
                Process[] _processes = Process.GetProcesses();
                foreach (Process process in _processes)
                {
                    if (!String.IsNullOrEmpty(process.MainWindowTitle))
                    {
                        item = new ComboBoxItem();
                        item.Content = process.MainWindowTitle;
                        item.ToolTip = process.MainWindowTitle;
    
                        list.Add(item);
                    }
                }
    
                cbProcesses.ItemsSource = list;
            }
    
            private void cbProcesses_MouseEnter(object sender, MouseEventArgs e)
            {
                
            }
        }
    }
