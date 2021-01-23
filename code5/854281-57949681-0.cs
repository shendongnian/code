  [Route("api/[controller]")]
  [ApiController]
  public class FooController : ControllerBase {
    //Use Autowired injection.
    [Autowired]
    private readonly FooService fooService;
    [HttpGet]
    public ActionResult<string> Get() {
      return fooService == null ? "failure" : "success";
    }
  }
