    public class MyController : ApiController
    {
        private readonly IMyManager _myManager;
        public FileController(IMyManager myManager)
        {
            _myManager = myManager
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _myManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
