    public class BetterComboBox : System.Windows.Forms.ComboBox
    {
        public BetterComboBox(List<SomeObject> list)
        {
             // This call is required by the Windows.Forms Form Designer.
             InitializeComponent();
             
             //you can pass over the list from parameter or initialize it right here.
             //if you need to call a store procedure or something, do it here.
             this.DataSource = list;
        }
        //other methods that you need to override or write
    }
 
