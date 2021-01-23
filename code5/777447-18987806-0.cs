      public JsonResult Search(string input, SearchBy searchBy)
      {          
            Manager manger = new Manager();
            List<string> MyList = manger.GetData(input, searchBy);                                                         
            return Json(MyList, JsonRequestBehavior.AllowGet);
      }
