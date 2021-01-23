    public partial class ShellWindow: Window
    {
        public enum PagesTypes { Login, Home }
        PagesTypes currentOpenedPage;
        LoginUserControl login;
        HomeUserControl home;
        public WindowController()
        {
            InitializeComponent();
            login = new LoginUserControl ();
            login.GoToPage += new LoginUserControl.ChangePageHandler(GoToPage);
            GoToPage(PagesTypes.Login);
        }
        public void GoToPage(PagesTypes page)
        {
            switch (page)
            {
                case PagesTypes.Login:
                //Close last opened usercontrol, 
                ....
                //open new usercontrol
                login = new LoginUserControl();
                contentpresenter.content = login;
                break;
                //other pages cases
                ....
            }
            currentOpenedPage = page;
        }
    }
