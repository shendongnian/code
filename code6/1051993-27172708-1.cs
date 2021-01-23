    namespace SO.Q_27171497.Wpf
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Windows;
        using System.Windows.Controls;
    
        public partial class MainWindow
        {
            private readonly Dictionary<string, int> config = new Dictionary<string, int>
            {
                {"tree", 1},
                {"chair", 4},
                {"window", 3},
                {"dollar", 200}
            };
    
            public MainWindow()
            {
                this.InitializeComponent();
            }
    
            private void Button_OnClick(object sender, RoutedEventArgs e)
            {
                var button = sender as Button;
                if (button == null)
                {
                    return;
                }
                button.Content = this.config.FirstOrDefault(c => String.CompareOrdinal(button.Name, c.Key) == 0).Value;
            }
        }
    }
