    public partial class TestControl : UserControl {
        public TestControl( ) {
            //...
            for ( int i = 0; i < Controls.Count; i++ ) {
                Controls[ i ].Click += Item_Click;
            }
        }
        //...
    }
