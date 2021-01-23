    public partial class LoginUserControl : UserControl
    {
        internal delegate void ChangePageHandler(ShellWindow.PagesTypes toPage);
        internal event ChangePageHandler GoToPage;
        public LoginUserControl()
        {...}
        
        //Methods for login 
        .....
        internal void LoginOK()
        {
            if(this.GoToPage != null)
                GoToPage(ShellWindow.PagesTypes.Home);
        }
    }
