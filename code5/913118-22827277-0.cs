        private void SomeFunction(string username, string password)
        {
            try
            {
                try
                {
                    _someObject.DoSpecialPrivilegedFunction(username, password);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new UserUnauthorizedException(username, "DoSpecialPrivilegedFunction", ex);
                }
                catch (IOException ex)
                {
                    throw new UserModuleActionException("A network IO error happend.", username, "DoSpecialPrivilegedFunction", ex);
                }
                //Other modules
            }
            catch (Exception ex)
            {
                //If it is one of our custom expections, just re-throw the exception.
                if (ex is UserActionException)
                    throw;
                else
                    throw new UserActionException("A unknown error due to a user action happened.", username, ex);
            }
        }
    //elsewhere
    [Serializable]
    public class UserUnauthorizedException : UserModuleActionException
    {
        private const string DefaultMessage = "The user attempted to use a non authorized module";
        public UserUnauthorizedException()
            : base(DefaultMessage)
        {
        }
        public UserUnauthorizedException(string message) 
            : base(message)
        {
        }
        public UserUnauthorizedException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        public UserUnauthorizedException(string username, string module, Exception innerException = null) : base(DefaultMessage, username, module, innerException)
        {
        }
        protected UserUnauthorizedException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
    [Serializable]
    public class UserModuleActionException : UserActionException
    {
        private readonly string _module;
        public UserModuleActionException()
        {
        }
        public UserModuleActionException(string message) : base(message)
        {
        }
        public UserModuleActionException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public UserModuleActionException(string message, string username, string module, Exception innerException = null)
            : base(message, username, innerException)
        {
            _module = module;
        }
        protected UserModuleActionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
        public virtual string Module
        {
            get { return _module; }
        }
        public override string Message
        {
            get
            {
                string s = base.Message;
                if (!String.IsNullOrEmpty(_module))
                {
                    return s + Environment.NewLine + String.Format("Module: {0}", _module);
                }
                return base.Message;
            }
        }
    }
    [Serializable]
    public class UserActionException : Exception
    {
        private readonly string _username;
        public UserActionException()
        {
        }
        public UserActionException(string message)
            : base(message)
        {
        }
        public UserActionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public UserActionException(string message, string username, Exception innerException = null)
            : base(message, innerException)
        {
            _username = username;
        }
        protected UserActionException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
        public override string Message
        {
            get
            {
                string s = base.Message;
                if (!String.IsNullOrEmpty(_username))
                {
                    return s + Environment.NewLine + String.Format("Username: {0}", _username);
                }
                return base.Message;
            }
        }
        public virtual string Username
        {
            get { return _username; }
        }
    }
