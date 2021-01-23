    public class ValuesController : ApiController
    {
        private Model1Container _model1 = new Model1Container();
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_model1 != null)
                {
                    _model1.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
