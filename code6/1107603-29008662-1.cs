    public JsonResult IsFooUnique(int ID, string Foo)
   		{
  			bool isUnique = false; // ... your logic here
   			return Json(isUnique, JsonRequestBehavior.AllowGet);
   		}
