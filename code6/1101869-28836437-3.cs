    public class CreateThingCommand : CommandBase<ThingViewModel>
    {
        private readonly DbContext _context;
        
        public CreateThingCommand(DbContext context)
        {
            _context = context;
        }
        public override ICommandResponse Handle(ThingViewModel viewModel)
        {
            var model = viewModel.ToActualModel();
            
            model.RelatedThing =
                model.RelatedThingId == null
                ? null
                : _context.RelatedThings.Single(v => v.Id == model.RelatedThingId);
            model.UtcCreatedOn = DateTime.UtcNow;
            _context.Thing.Add(model);
            _context.SaveChanges();
            
            return Success();
        }
    }
    // Inside controller
    public ActionResult Create(ThingViewModel vModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = createThingCommand.Handle(vModel);
                
                if(result.Success)
                {
                    var successMessage = "You have created a new Thing!";
                    return RedirectToAction("Index", new { successMessage = successMessage });
                }
                
                // Handle error
                return RedirectToAction("Index", new { failMessage = "Something went wrong" });
            }
            
            ViewBag.EntityName = "Thing";
            ViewBag.ControllerName = "Thing";
            ViewBag.Title = "Admin | Thing - Create";
            return View("~/Views/Thing/Create.cshtml", vModel);
        }
        catch(Exception e)
        {
            var errorMessage = "An error occured when creating a new thing!";
            return RedirectToAction("Index", new { errorMessage = errorMessage });
        }
    }
