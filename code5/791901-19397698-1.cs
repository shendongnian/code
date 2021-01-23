    public ActionResult testAction(string name, int age)
        {
            YourModel ym = new YourModel();
            ym.Name = name;
            ym.Age = age;
            return Json(ym, JsonRequestBehavior.AllowGet);
        }
