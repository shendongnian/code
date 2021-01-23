        [HttpPost]
        public ActionResult AppEditDocketCreate([DataSourceRequest] DataSourceRequest  request, [Bind(Prefix = "models")]IEnumerable<UDocket> uDockets)
        {
            try
            {
                if (uDockets != null && ModelState.IsValid)
                {
                    using (IVSourceEntities db = new IVSourceEntities())
                    {
                        
                        TBL_Docket tblDocket = new TBL_Docket();
                        foreach (var uDocket in uDockets)
                        {
                            tblDocket.DocketName = uDocket.DocketName;
                           
                            tblDocket.CreatedDate = System.DateTime.Now;
                           
                            db.TBL_Docket.Add(tblDocket);
                            db.SaveChanges(); 
                        }
                    }
                }
            }
           catch (DbEntityValidationException e)
            {
            }
            return Json(ModelState.ToDataSourceResult());
           
        }
