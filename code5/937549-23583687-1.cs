        public GnipSubmittingService(
            IGnipHistoricConnection gnip,
            IUserDataInterface userDb,
            IBuilder<string, int> titleBuilder,
            IBuilder<DateTime, DateTime> endDateBuilder,
            ISendEmailService emailService,
            IEnumerable<MailAddress> errorEmailRecipients,
            ILog log)
        {
            _gnip = gnip;
            _userDb = userDb;
            _titleBuilder = titleBuilder;
            _endDateBuilder = endDateBuilder;
            _emailService = emailService;
            _errorEmailRecipients = errorEmailRecipients;
            _log = log;
        }
