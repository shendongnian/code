    public partial class UserControl1 : public UserControl
    {
        UserControl1( )
        {
            this.DataContext = new ViewModel( );
        }
    }
