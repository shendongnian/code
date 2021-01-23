    using System.Windows;
    using System.Runtime.InteropServices;
    using System;
    using System.Windows.Input;
    
    namespace WpfApplicationDemo
    {
        /// <summary>
        /// Interaction logic for ComboInScrollViewer.xaml
        /// </summary>
        public partial class ComboInScrollViewer : Window
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetActiveWindow();
    
            public ComboInScrollViewer()
            {
                InitializeComponent();
                listContainer.Items.Add("1st");
                listContainer.Items.Add("2nd");
                listContainer.Items.Add("3rd");
                listContainer.Items.Add("4th");
                listContainer.Items.Add("5th");
                listContainer.Items.Add("6th");
            }
    
            private void ScrollViewer_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
            {
                if (e.Key == Key.PageUp || e.Key == Key.Prior)
                {
                    listContainer.RaiseEvent(new KeyEventArgs(InputManager.Current.PrimaryKeyboardDevice, PresentationSource.FromVisual(listContainer),
                        1, Key.Home) { RoutedEvent = Keyboard.KeyDownEvent }
                    );
                    e.Handled = true;
                }
                else if (e.Key == Key.PageDown || e.Key == Key.Next)
                {
                    listContainer.RaiseEvent(new KeyEventArgs(InputManager.Current.PrimaryKeyboardDevice, PresentationSource.FromVisual(listContainer),
                        1, Key.End) { RoutedEvent = Keyboard.KeyDownEvent }
                    );
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    listContainer.RaiseEvent(new KeyEventArgs(InputManager.Current.PrimaryKeyboardDevice, PresentationSource.FromVisual(listContainer),
                        1, Key.End) { RoutedEvent = Keyboard.KeyDownEvent } 
                    );
                }
                catch (Exception objExp)
                {
                    // Handle Error
                }
            }
        }
    }
