    using System;
    using System.Windows;
    
    namespace WpfApplication4
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DateTime oldTime, newTime;
                TimeSpan delta;
    
                var iterations = 100000;
    
                #region Test performance 1
    
                oldTime = DateTime.Now;
                for (var i = 0; i < iterations; i++)
                    txtbx1.Text = "";
                newTime = DateTime.Now;
                delta = newTime - oldTime;
                txtbx1.Text = delta.Milliseconds.ToString();
    
                #endregion
    
                #region Test performance 2
    
                oldTime = DateTime.Now;
                for (var i = 0; i < iterations; i++)
                    txtbx2.Text = string.Empty;
                newTime = DateTime.Now;
                delta = newTime - oldTime;
                txtbx2.Text = delta.Milliseconds.ToString();
    
                #endregion
    
                #region Test performance 3
    
                oldTime = DateTime.Now;
                for (var i = 0; i < iterations; i++)
                    txtbx3.Text = null;
                newTime = DateTime.Now;
                delta = newTime - oldTime;
                txtbx3.Text = delta.Milliseconds.ToString();
    
                #endregion
    
                #region Test performance 4
    
                oldTime = DateTime.Now;
                for (var i = 0; i < iterations; i++)
                    txtbx4.Clear();
                newTime = DateTime.Now;
                delta = newTime - oldTime;
                txtbx4.Text = delta.Milliseconds.ToString();
    
                #endregion
            }
        }
    }
