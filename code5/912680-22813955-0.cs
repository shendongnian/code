    public class GamesController : Controller
    {
      // eg. /Games/Game/1
      public ActionResult Game(int id){
        var SequenceModel = SequenceRepository.GetSequenceById(id); //some way of getting your model from the ID
        return View(SequenceModel);
      }
    }
