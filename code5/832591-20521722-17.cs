        [HttpGet]
        public ActionResult Add_Update_Staff()
         {
              var model = new MyViewModel
            {
                ListStaffVms = (from a in db.Prm_Staffs
                                where a.Active == true
                                orderby a.LName ascending
                                select new Staff_VM
                                {
                                    ID = a.Id,
                                    SalutationID = a.SalutationID,
                                    FName = a.FName,
                                    LName = a.LName,
                                    Active = a.Active,
                                    AvailableSalutations = (from p in db.Prm_Salutations
                                                             where a.Active == true
                                                            orderby p.Desc ascending
                                                            select p).ToList()
                                }).ToList(),
                StaffVm = new Staff_VM()
                {
                    AvailableSalutations = (from p in db.Prm_Salutations
                                             where a.Active == true
                                            orderby p.Desc ascending
                                            select p).ToList()
                }
            };
            return View(model);
        }
