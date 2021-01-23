    namespace EventSample
    {
        public partial class BControl : UserControl
        {
            public BControl()
            {
                InitializeComponent();
            }
    
            private void BControl_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("B Control fired Key down");
                GlobalEvent.Invoke(this, e.KeyCode);
            }
        }
    }
