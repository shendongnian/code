    [Route("{param?}")]
    [Authorize]
    public ActionResult Index(string param = null) {
       ...
    }
