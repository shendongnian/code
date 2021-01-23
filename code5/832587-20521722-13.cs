        [HttpGet]
        public ActionResult Add_Update_Staff()
         {
            var activeSalts = (from a in db.Prm_Salutations
                    where a.Active == true
                    orderby a.Desc ascending
                    select a).toList();
            var model = new MyViewModel
            {
                ListStaffVms = (from a in db.Prm_Staffs
                                where a.Active == true
                                orderby a.LName ascending
                                select new Staff_VM
                                {
                                    ID = a.ID,
                                    SalutationID = a.SalutationID,
                                    FName = a.FName,
                                    LName = a.LName,
                                    Active = a.Active,
                                    AvailableSalutations = activeSalts;
                                }),
                StaffVm = new Staff_VM()
                {
                    AvailableSalutations = activeSalts
                }
            };
            return View(model);
        }
