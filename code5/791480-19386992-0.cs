    public class mycontroller
    {
        private readonly IService _service;
    ...
        public ActionResult myaction()
        {
            _service.dowork(ModelState.ToWrapper())
     ....
