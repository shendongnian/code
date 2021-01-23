    using System;
    
    namespace UnitTestProject2
    {
        public class GetDataViewModel
        {
            IMediator mediator;
            public GetDataViewModel(IMediator mediator)
            {
                this.mediator = mediator;
                this.mediator.ListenFor("LoggedIn", LoggedIn);
            }
            protected string UserId;
            protected void LoggedIn(Object sender, EventArgs e)
            {
                UserId = sender.ToString();
            }
        }
    
        public class LoginViewModel
        {
            IMediator mediator;
            public LoginViewModel(IMediator mediator)
            {
                this.mediator = mediator;
            } 
    
            public string UserId { get; set; }
            public void Login(string userid)
            {
                this.UserId = userid;
                this.mediator.RaiseEvent("LoggedIn", this.UserId);
            }
        }
    
        public interface IMediator
        {
            public void ListenFor(string eventName, EventHandler action );
            public void RaiseEvent(string eventName, object data);
        }
    }
