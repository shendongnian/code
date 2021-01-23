    public interface IMessageService
    {
        void ShowErrorMessage(Exception e);
    }
    public abstract class PresenterBase
    {
        private readonly IMessageService _messageService;
        public PresenterBase(IMessageService messageService)
        {
            this._messageService = messageService;
        }
        protected void ExecuteAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception e) { this._messageService.ShowErrorMessage(e); }
        }
    }
    public class SearchPresenter: PresenterBase
    {
        public SearchPresenter(IMessageService messageService)
            : base(messageService)
        {
        }
        public void Search()
        {
            this.ExecuteAction(() =>
            {
                //perform search action
            });
        }
    }
