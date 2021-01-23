    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public ComboBox ComboBox {
        get {
          return this.comboBox1;
        }
      }
    }
