    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
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
    
    namespace staThread
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Thread keyboardThread;
    
            public MainWindow()
            {
                InitializeComponent();
                keyboardThread = new Thread(new ThreadStart(KeyboardThread));
                keyboardThread.SetApartmentState(ApartmentState.STA);
                keyboardThread.Start();
            }
    
            void KeyboardThread()
            {
                while (true)
                {
                    if (Keyboard.IsKeyDown(Key.A))
                    {
                    }
    
                    Thread.Sleep(100);
                }
            }
        }
    }
