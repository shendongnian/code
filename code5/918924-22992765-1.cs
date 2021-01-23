    public partial class UserControl1 : UserControl {
      public UserControl1() {
        InitializeComponent();
      }
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      public ControlBindingsCollection ComboDataBindings {
        get {
          return this.comboBox1.DataBindings;
        }
      }
    }
