    [Route("/a")]
    public class GetAs : IReturn<List<A>>
    {
        public bool IncludeB { get; set; }
        public bool IncludeC { get; set; }
    }
    public class AService : Service
    {
        private readonly AContext _aContext;
        public AService(AContext aContext)
        {
            _aContext = aContext;
        }
        public object Get(GetAs req)
        {
            var res = _aContext.As;
            if (req.IncludeB)
                res = res.Include("B");
            if (req.IncludeC)
                res = res.Include("C");
            return res.ToList();
        }
    }
