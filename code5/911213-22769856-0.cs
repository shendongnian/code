     public class CmdController : Controller
     {
        
        public CmdController()
        {         
        }
        
        [HttpGet]
        public ActionResult Cmd()
        {
            return View((object)"Greetings!");
        }
        [HttpPost]
        public ActionResult Cmd(string inputCommand)
        {
            SSH s = new SSH();
            s.cmdInput = inputCommand;
            string outputText = s.SSHConnect();
            return View((object)outputText);
        }
     }
    // Simple partial view for Cmd Action
    // You can use your own class instead of string model.
    @model string
    @{
        ViewBag.Title = "Cmd";
    }
    <h2>Cmd</h2>
    @using (Html.BeginForm())
    {
        <strong>command output:</strong>
        <div>@Model</div>
        @Html.TextBox("inputCommand")
        <button type="submit">Go!</button>
    }
