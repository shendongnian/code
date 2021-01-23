    public class LoggedInActivity
    {
        [Test]
        public void TestLoggingIn()
        {
            var sessionManager = new SessionManager();
            var afterLogIn = Observable.FromEventPattern<SessionEventArgs>(
                h => sessionManager.AfterLogin += h,
                h => sessionManager.AfterLogin -= h)
                .Select(x => x.EventArgs.UserId);
            var beforeLogOff = Observable.FromEventPattern<SessionEventArgs>(
                h => sessionManager.BeforeLogoff += h,
                h => sessionManager.BeforeLogoff -= h)
                .Select(x => x.EventArgs.UserId);
            var loggedIn = afterLogIn.GroupByUntil(
                userId => userId,
                login => beforeLogOff.Where(y => y == login.Key));
            Func<IGroupedObservable<int, int>, IObservable<string>> whileLoggedIn = login =>
                Observable.Using(
                    () => sessionManager.AddSession(new Session(login.Key)),
                    session => Observable.FromEventPattern(
                        h => session.SomeEvent += h,
                        h => session.SomeEvent -= h)
                        .Select(x => "User " + login.Key + " had SomeEvent!")
                        .TakeUntil(login.LastAsync()));
            // Single non-terminating stream that captures
            // all events occuring during any login 
            var loggedInEvents = loggedIn.SelectMany(whileLoggedIn);
            loggedInEvents.Subscribe(Console.WriteLine);
            sessionManager.Login(1);
            sessionManager.Sessions[1].RaiseSomeEvent();
            sessionManager.Login(2);
            sessionManager.Sessions[1].RaiseSomeEvent();
            sessionManager.Sessions[2].RaiseSomeEvent();
            sessionManager.Logoff(2);
            sessionManager.Logoff(1);
        }
    }
    public class SessionManager
    {
        public event EventHandler<SessionEventArgs> AfterLogin;
        public event EventHandler<SessionEventArgs> BeforeLogoff;
        private readonly Dictionary<int, Session> _sessions = new Dictionary<int, Session>();
        public Dictionary<int, Session> Sessions { get { return _sessions; } }
        public void Login(int userId)
        {
            var temp = AfterLogin;
            if (temp != null)
            {
                AfterLogin(this, new SessionEventArgs(userId));
            }
        }
        public Session AddSession(Session session)
        {
            _sessions.Add(session.UserId, session);
            return session;
        }
        public void Logoff(int userId)
        {
            var temp = BeforeLogoff;
            if (temp != null)
            {
                BeforeLogoff(this, new SessionEventArgs(userId));
            }
            Sessions.Remove(userId);
        }
    }
    public class Session : IDisposable
    {
        private readonly int _userId;
        public int UserId { get { return _userId; } }
        public Session(int userId)
        {
            _userId = userId;
            Console.WriteLine("User " + _userId + " logged in.");
        }
        public event EventHandler SomeEvent;
        public void RaiseSomeEvent()
        {
            var temp = SomeEvent;
            if (temp != null)
            {
                SomeEvent(this, EventArgs.Empty);
            }
        }
        public void Dispose()
        {
            Console.WriteLine("User " + _userId + " logged out.");
        }
    }
    public class SessionEventArgs : EventArgs
    {
        private readonly int _userId;
        public SessionEventArgs(int userId)
        {
            _userId = userId;
        }
        public int UserId { get { return _userId; } }
    }
