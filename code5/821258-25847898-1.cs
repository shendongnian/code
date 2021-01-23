    public class BasicController : Controller
    {
        public ActionResult GetModel()
        {
            MainModel mainModel = new MainModel();
            List<SimpleDropdown> dropdownlist = new List<SimpleDropdown>();
            List<SingleEntity> selist = new List<SingleEntity>();
            for (int j = 1; j < 10; j++)
            {
                dropdownlist.Add(new SimpleDropdown { Text = "Text" + j, Value = j.ToString() });
            }
            SingleEntity se;
            for (int i = 0; i < 10; i++)
            {
                se = new SingleEntity();
                se.Id = i;
                se.Name = "Name" + i;
                se.SelectedEmp = i;
                se.dddl = dropdownlist;
                mainModel.main_model_list = selist;
                mainModel.main_model_list.Add(se);
            }
            return View(mainModel);
        }
        [HttpPost]
        public ActionResult SaveModel(MainModel mainModelasdfafsf)
        {
            // do stuff here... please not only selectedEmp only will get reflected but not the property ddl since its again another list
            return View("GetModel");
        }
    }
