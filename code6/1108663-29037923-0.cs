    public interface IUiDisplay
    {
        void Show();
    }
    public class CreateCategoryCommand : ICommand 
    {
        public CreateCategoryCommand(IUiDisplay uiDisplay) {
            if(display == null) throw new ArgumentNullException("uiDisplay");
            this.display = uiDisplay;
        }
        private readonly IUiDisplay display;
        ...
    }
