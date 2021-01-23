    namespace EventSample
    {
        public partial class AControl : UserControl
        {
            public event AfterChildEventHandler OnChildFireEvent;
            public AControl()
            {
                InitializeComponent();
            }
    
            private void AControl_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("A Control fired Key down");
                if (OnChildFireEvent != null)
                    OnChildFireEvent(this, e.KeyCode);
            }
        }
    }
