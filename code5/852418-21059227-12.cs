    public partial class Mywindow : ViewBase
    {
        public Mywindow()
        {
            InitializeComponent();
            DataContext = new MyViewModel(Token);
        }
        protected override void HandleWindowLevelMessage(Message message)
        {
            //open window according to OP Requirement
            if (message.MessageType == MessageType.OpenWindow)
            {
                string windowName = message.ToString();
                if (windowName != null)
                {
                    //logic to get the window . I assume that OP have some logic to get the child window this is just temporary
                    var window = Application.Current.Windows.OfType<Window>().FirstOrDefault(s=>s.Name==windowName);
                    if (window != null)
                    {
                       window.Owner=this;
                        window.Show();
                    }
                }
            }
            base.HandleWindowLevelMessage(message);
        }
    }
