public interface IDialogFactory {
    IDialogView CreateNew();
}
// Implementation
sealed class DialogFactory: IDialogFactory {
   public IDialogView CreateNew() {
      return new DialogImpl();
   }
}
// or singleton...
sealed class SingleDialogFactory: IDialogFactory {
   private IDialogView dialog;
   public IDialogView CreateNew() {
      if (dialog == null) {
         dialog = new DialogImpl();
      }
      return dialog;
   }
}
