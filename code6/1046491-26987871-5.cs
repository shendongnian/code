    public partial class BControl : UserControl
        {
            public event AfterChildEventHandler OnChildFireEvent;
            public BControl()
            {
                InitializeComponent();
            }
    
            private void BControl_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show("B Control fired Key down");
                if (OnChildFireEvent != null)
                    OnChildFireEvent(this, e.KeyCode);
            }
        }
