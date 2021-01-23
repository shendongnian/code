    [RoutePrefix("incidents")]
    public sealed class IncidentsController : Controller
    {    
        [HttpGet, Route("action/{id:int?}/{error?}", Name = "IncidentsGetAction")]
        public async Task<ActionResult> Action(int? id, string error = null)
    
        [HttpPost, Route("action", Name = "IncidentsPostActionAccept"), ActionName("Action"), ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Accept")]
        public async Task<ActionResult> ActionAccept(IncidentActionViewModel incident)
    
        [HttpPost, Route("action", Name = "IncidentsPostActionReject"), ActionName("Action"), ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Reject")]
        public async Task<ActionResult> ActionReject(IncidentActionViewModel incident)
    }
    
    // Generate a URL
    @Url.RouteUrl("IncidentsGetAction", new { id = 10 })
    // Generate a link to a URL
    @Html.RouteLink("Link Text", "IncidentsGetAction", new { id = 10 })
