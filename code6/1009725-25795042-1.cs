    // base classes
    public abstract class BaseViewPresenter { }
    public abstract class BaseView : UserControl 
    {
        public BaseViewPresenter Presenter { get; set; }
    }
    public abstract class BaseView<T> : BaseView
        where T : BaseViewPresenter
    {
        public new T Presenter
        {
            get { return base.Presenter as T; }
            set { base.Presenter = value; }
        }
    }
    
    // specific classes
    public class LoginPresenter : BaseViewPresenter { }
    public partial class LoginView : BaseView<LoginPresenter> 
    {
         // Can now call things like Presenter.LoginPresenterMethod()
    }
    
    // updated .Resolve method used for obtaining UI object
    public BaseView Resolve(BaseViewPresenter presenter)
    {
        var type = model.GetType();
        var viewType = _dataTemplates[type];
    
        BaseView view = Activator.CreateInstance(viewType) as BaseView;
        view.Presenter = presenter;
    
        return view;
    }
