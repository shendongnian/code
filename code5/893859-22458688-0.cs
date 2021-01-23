    public class LessonControler{
    
       [AllowGet]
       public JsonResult DeleteLesson(long LessonID){
          //DoTheDeletion magic here
          return Json(new {Done="OK", Error=""}, JsonRequestBehavior.AllowGet);
      }
    
    }
