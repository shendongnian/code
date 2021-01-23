        private static NotificationService _service;
        public TemplateController()
        {
            _service = new NotificationService(new NotificationContext());
        }
        public void Dispose()
        {
            _service.Dispose();
        }
