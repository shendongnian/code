    namespace EventSample
    {
        public partial class AControl : UserControl
        {
            public AControl()
            {
                InitializeComponent();
            }
    
            private void AControl_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("A Control fired Key down");
                GlobalEvent.Invoke(this, e.KeyCode);
            }
        }
    }
