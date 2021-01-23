    using System;
    using System.Timers;
    using System.Windows;
    
    namespace Media
    {
        /// <summary>
        /// Interaction logic for pour MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public TimeSpan Position { get; set; }
    
            Timer _updateTimer;
    
            public MainWindow()
            {
                InitializeComponent();
    
                //Timer interval fixed to 1 second to read the actual position of the first media element
                this._updateTimer = new Timer(1000);
                this._updateTimer.Elapsed += this.UpdateTimerElapsed;
            }
            
            //The callback of your update timer
            private void UpdateTimerElapsed(object sender, ElapsedEventArgs e)
            {
                //I use the dispatcher because you call the Position from another thread so it has to be synchronized
                Dispatcher.Invoke(new Action(() => this.Position = firstMediaElement.Position));
            }
    
            //When stopping the first, you start the second and set its Position
            private void OnLaunchNextButtonClick(object sender, RoutedEventArgs e)
            {
                this.firstMediaElement.Stop();
    
                this.secondMediaElement.Volume = 10;
                this.secondMediaElement.Play();
                this.secondMediaElement.Position = this.Position;
            }
    
            //When you start the first, you have to start the update timer
            private void OnLaunchFirstButtonClick(object sender, RoutedEventArgs e)
            {
                this.firstMediaElement.Play();
                this._updateTimer.Start();
            }
        }
    }
