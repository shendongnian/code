    using System;
    
    namespace UnitTestProject3
    {
        public class GetDataViewModel
        {
            protected string UserId;
            public void LoggedIn(Object sender, EventArgs e)
            {
                UserId = sender.ToString();
            }
        }
    
        public class LoginViewModel
        {
            public EventHandler OnLogin;
            public string UserId { get; set; }
            public void Login(string userid)
            {
                this.UserId = userid;
                if (this.OnLogin != null)
                {
                    this.OnLogin(this.UserId, null);
                }
            }
        }
    
        public class Controller // or MasterViewModel
        {
            public void SetUp()
            {
                GetDataViewModel vm1 = new GetDataViewModel();
                LoginViewModel vm2 = new LoginViewModel();
                vm2.OnLogin += vm1.LoggedIn;
    
                //wire up to views and display
            }
        }
    }
