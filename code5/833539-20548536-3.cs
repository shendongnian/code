    public ActionResult Create(FeatureTypeCreate featureType)
    {
       _Uow.SectionRepository.Create(featureType.ToModel());
       _Uow.Save(); //Saving is the responsibility of the Unit Of Work 
                    //not the Repository
    }
