    [HttpPost]
            public string SendIndoorRequest(TestRequestViewModel form, IEnumerable<HttpPostedFileBase> files)
            {
    
                using (var db = new cloud_clinicEntities())
                using (var scope = new TransactionScope())
                {
                    org_requestm objRequestM = new org_requestm();
    
                    objRequestM.authcode1 = form.AuthCode1;
                    objRequestM.admission_no = form.admission_no;
                    objRequestM.bed_no = form.bed_no;
                    objRequestM.ward_no = form.ward_no;
                    objRequestM.patient_id = form.patient_id;
                    objRequestM.RequestType = form.TypeOfRequest;
                    if (form.DependentId == 0)
                    {
                        objRequestM.cliq_dependent_id = null;
                    }
                    else
                    {
                        objRequestM.cliq_dependent_id = form.DependentId;
                    }
                    if (form.CliqDoctorID != 0)
                    {
                        objRequestM.cliq_doctor_id = form.CliqDoctorID;
                    }
                    if (!string.IsNullOrEmpty(form.DoctorName))
                    {
                        objRequestM.doctor_name = form.DoctorName;
                    }
    
                    objRequestM.request_total_amount = 0;
    
                    for (int i = 0; i < form.BookedTests.Count; i++)
                    {
                        if (form.BookedTests[i].Charges != 0)
                        {
                            objRequestM.request_total_amount = objRequestM.request_total_amount + form.BookedTests[i].Charges;
                        }
                    }
    
    
                    objRequestM.cliq_panel_id = form.CliqPanelID;
    
                    if (Session["AccountType"].ToString() == "lab")
                    {
                        objRequestM.enteredby_clinicPersonId = int.Parse(Session["userId"].ToString());
                    }
                    else
                    {
                        objRequestM.enteredby_orgPersonId = int.Parse(Session["userId"].ToString());
                    }
                    objRequestM.enteredon = DateTime.Now;
    
                    objRequestM.org_request_type_id = form.RequestType;
    
                    if (Request.Files != null)
                    {
                        foreach (string requestFile in Request.Files)
                        {
                            HttpPostedFileBase file = Request.Files[requestFile];
                            if (file.ContentLength > 0)
                            {
                                string fileName = Path.GetFileName(file.FileName);
                                string directory = Server.MapPath("~/uploads/");
    
                                if (!Directory.Exists(directory))
                                {
                                    Directory.CreateDirectory(directory);
                                }
                                string path = Path.Combine(directory, fileName);
    
                                file.SaveAs(path);
    
                                objRequestM.perscription_doc_path = "~/Uploads/" + file.FileName;
                            }
                        }
                    }
    
                    db.org_requestm.Add(objRequestM);
    
                    db.SaveChanges();
    
    
                    long RequestmId = db.org_requestm.Max(o => o.id);
    
                    for (int i = 0; i < form.BookedTests.Count; i++)
                    {
                        
                            if (form.BookedTests[i].TestId != 0)
                            {
                                org_requestd objRequestd = new org_requestd();
    
                                objRequestd.amount = form.BookedTests[i].Charges;
                                objRequestd.lims_test_id = form.BookedTests[i].TestId;
                                objRequestd.lims_test_name = form.BookedTests[i].TestName;
                                objRequestd.Status = "P";
                                objRequestd.requestm_id = RequestmId;
    
    
                                db.org_requestd.Add(objRequestd);
    
                                try
                                {
                                    db.SaveChanges();
                                }
                                catch (System.Data.Entity.Validation.DbEntityValidationException e)
                                {
                                    var outputLines = new List<string>();
                                    foreach (var eve in e.EntityValidationErrors)
                                    {
                                        outputLines.Add(string.Format(
                                            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                                            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                                        foreach (var ve in eve.ValidationErrors)
                                        {
                                            outputLines.Add(string.Format(
                                                "- Property: \"{0}\", Error: \"{1}\"",
                                                ve.PropertyName, ve.ErrorMessage));
                                        }
                                    }
                                    System.IO.File.AppendAllLines(@"d:\EFerrors.txt", outputLines);
                                }
                            }
    
                    }
    
    
                    scope.Complete();
    
    
                    Session.Remove("BookedTests");
    
                    return "success";
                }
            }
