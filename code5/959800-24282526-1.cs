    [HttpPost]
        public ActionResult Create(StyleItemCreateCommand command)
        {
            if (command != null) {
                string value1 = command.SelectedItemToColorMap["1391"];
                string value2 = command.SelectedItemToColorMap["21531"];
                Debug.Assert(value1 == "583" && value2 == "7733");
            }
            return View();
        }
