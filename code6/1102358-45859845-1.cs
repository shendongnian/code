    public MyTestController
    {
        private readonly IMyJobService _myJobService;
        
        public MyTestClass(IMyJobService myJobService)
        {
            _myJobService = myJobService;
        }
        
        public ActionResult Work()
        {
            BackgroundJob.Enqueue(() => _myJobService.DoWork());
            return Ok();
        }
    }
