    using System;
    using System.Threading.Tasks;
    using System.Windows;
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateButtonVisualState();
            LoginProcessing();
        }
        private async Task LoginProcessing()
        {
            // Simulating a long background task.
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
        private async Task UpdateButtonVisualState()
        {
            VisualStateManager.GoToState(LoginButton, "Pressed", useTransitions: true);
            await Task.Delay(TimeSpan.FromMilliseconds(200));
            VisualStateManager.GoToState(LoginButton, "Normal", useTransitions: true);
        }
    }
