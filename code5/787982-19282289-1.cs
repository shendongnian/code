    namespace WpfApplication1
    {
        using System;
        using System.Windows;
        using System.ComponentModel;
        using System.Runtime.CompilerServices;
        using System.Windows.Media;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private Form1 form1;
    
            public MainWindow()
            {
                InitializeComponent();
                this.form1 = new Form1();
                this.form1.ChangedColourEventHandler += this.TriggeredChangedColourEventHandler;
                form1.Show();
            }
    
            private Brush labelBgColour;
            public Brush LabelBgColour
            {
                get
                {
                    return this.labelBgColour;
                }
                set
                {
                    this.labelBgColour = value;
                    OnPropertyChanged();
                }
            }
    
            private void TriggeredChangedColourEventHandler(object sender, EventArgs ars)
            {
                this.LabelBgColour = this.form1.BgColour;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
    </Window>
