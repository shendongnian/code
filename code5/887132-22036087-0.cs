         public void Build<TBusinessLogic, TPresenter, TForm>(ILog logger)
            where TPresenter : PresenterClass, new()
                where TForm : FormClass, new()
        {
            _logger = logger;
            TBusinessLogic businessLogic = new BusinessLogicBuilder().Build<TBusinessLogic>();
            TPresenter presenter = new TPresenter(10);
                    TForm form = new TForm(20);
        } 
        public abstract class PresenterClass
        {
            public PresenterClass(int parm)
            {
            }
        }
    
        public abstract class FormClass
        {
            public FormClass(int parm)
            {
            }
        }
