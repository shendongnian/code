        private readonly bool _useLocalIdentity;
        public MyService(bool useLocalIdentity) :this()
        {
            _useLocalIdentity = useLocalIdentity;
        }
        private WindowsIdentity GetWindowsIdentity()
          {
            if (_useLocalIdentity)
            {
                return WindowsIdentity.GetCurrent();
            }
            var callerWinIdentity = ServiceSecurityContext.Current.WindowsIdentity;
            if (callerWinIdentity == null)
            {
                throw new InvalidOperationException("Caller not authenticated");
            }
            var cf = new ChannelFactory<IMyService>();
            cf.Credentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            return callerWinIdentity;
        }
