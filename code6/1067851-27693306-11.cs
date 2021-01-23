        /// <summary>
        /// Adds an operating system to the AddAppViewModel
        /// </summary>
        /// <param name="Guid">The Guid of the item</param>
        /// <param name="OS">The id of the operating system</param>
        /// <returns>PartialView _OperatingSystems</returns>
        [HttpPost]
        public ActionResult AddOperatingSystem(string Guid, int OS)
        {
            var viewmodel = EditedAppRepository.GetInstance().GetApp(Guid);
            viewmodel.AddOperatingSystem(OS);
            return PartialView("_OperatingSystems", viewmodel);
        }
        /// <summary>
        /// Removes an operating sytem from the AddAppViewModel
        /// </summary>
        /// <param name="Guid">The Guid of the item</param>
        /// <param name="id">The id of the operating system</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RemoveOperatingSystem(string Guid, int id)
        {
            var viewmodel = EditedAppRepository.GetInstance().GetApp(Guid);
            viewmodel.RemoveOperatingSystem(id);
            return PartialView("_OperatingSystems", viewmodel);
        }
