    // according to your data posted later
    
    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Modify(ClinicProfile clinicProfile, ContactData contactData, AdressData adressData)
            {
                ViewBag.Id = clinicProfile.Id;
    
                if (ModelState.IsValid)
                {
                    if (clinicProfile.Id != 0)
                    {
                        // here you want to tell the SharedContext to attach the contactData to the clinicProfile 
                        // you need to retrieve the lastVersion of contactData from db
                        var currentContactData=SharedContext.Current.ContactData.Single(t=>t.Id=contactData.Id);
                        // update the changed data in the currentContactData
                        clinicProfile.ContactData =currentContactData;  // instead of contactData;
                        clinicProfile.AdressData = adressData;
                        clinicProfile.AdressDataComposed = adressData.ComposeData();
                        clinicProfile.ContactDataComposed = contactData.ComposeData();
    
                        SharedContext.Current.Entry(clinicProfile).State = EntityState.Modified;
                        SharedContext.Current.SaveChanges();
    
                        Config.SaveClinicPhoto(clinicProfile.ClinicImageUpload, clinicProfile.Id);
                        Config.SaveClinicPreviewPhoto(clinicProfile.ClinicImageUpload, clinicProfile.Id);
    
                        return View(new ClinicProfileComposite { AdressData = adressData, ClinicProfile = clinicProfile, ContactData = contactData });
                    }
    
                    {
                        clinicProfile.ContactData = contactData;
                        clinicProfile.AdressData = adressData;
                        clinicProfile.AdressDataComposed = adressData.ComposeData();
                        clinicProfile.ContactDataComposed = contactData.ComposeData();
    
                        SharedContext.Current.Entry(clinicProfile).State = EntityState.Added;
                        SharedContext.Current.SaveChanges();
    
                        Config.SaveClinicPhoto(clinicProfile.ClinicImageUpload, clinicProfile.Id);
                        Config.SaveClinicPreviewPhoto(clinicProfile.ClinicImageUpload, clinicProfile.Id);
    
                        return RedirectToAction("Info", new { id = clinicProfile.Id });
                    }
                }
    
                ViewBag.Id = clinicProfile.Id;
                return View(new ClinicProfileComposite { AdressData = adressData, ClinicProfile = clinicProfile, ContactData = contactData });
            }
