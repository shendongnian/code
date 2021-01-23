public partial class MyView : Form, IMyView {
   private readonly IDialogFactory factory;
   public MyView(IDialogFactory factory) {
      InitializeComponent();
      //assert(factory != null);
      this.factory = factory;
   }
   public OpenDialogClick(object sender, EventArgs e) {
      using (var dialog = this.factory.CreateNew()) {
         dialog.ShowDialog(this);
      }
   }
}
