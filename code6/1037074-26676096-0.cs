    public abstract class EntityODataController<TEntity, TDto> : ODataController where TDto : class
    {
        public EntityODataController(ILogService logService) : base(logService) { }
    
        [HttpGet]
        public abstract IHttpActionResult Get(int id);
    
        [AcceptVerbs("PATCH", "MERGE")]
        public abstract Task<IHttpActionResult> Update([FromODataUri] int id, Delta<TDto> delta, CancellationToken ct);
    }
