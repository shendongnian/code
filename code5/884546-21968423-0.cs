    public class ChecklistController : ApiController
    {
        ...
        [System.Web.Http.HttpGet]
        public IEnumerable<Checklist> GetChecklists()
        {
            ...
        }
