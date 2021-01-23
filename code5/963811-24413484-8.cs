    [HttpPost]
    public ActionResult BundleStatusRead([DataSourceRequest] DataSourceRequest request)
    {                   
    
            var span = DateTime.Today.AddDays(-1);
            DataAccessAdapter adapter = new DataAccessAdapter();
            EntityCollection allBundles = new EntityCollection(new CarrierBundleEntityFactory());
            RelationPredicateBucket filter = new RelationPredicateBucket(CarrierBundleFields.Date <= span);
            adapter.FetchEntityCollection(allBundles, filter);
                
            
            //...Using AutoMapper
            Mapper.CreateMap<MyProjectNamespace.Models.CarrierBundleModel, ZoomAudits.DAL.EntityClasses.CarrierBundleEntity>();   
            List<MyProjectNamespace.Models.CarrierBundleModel> viewModelList =Mapper.Map<List<ZoomAudits.DAL.EntityClasses.CarrierBundleEntity>, List<MyProjectNamespace.Models.CarrierBundleModel>>(allBundles);
            return Json(viewModelList.ToDataSourceResult(request));
    
            //...Not using AutoMapper
            List<MyProjectNamespace.Models.CarrierBundleModel> viewBundles=new List<MyProjectNamespace.Models.CarrierBundleModel>();
            foreach(ZoomAudits.DAL.EntityClasses.CarrierBundleEntity entityBundle in allBundles)
            {
                MyProjectNamespace.Models.CarrierBundleModel model=new MyProjectNamespace.Models.CarrierBundleModel();
                model.BundleID=entityBundle.BundleId;
                model.CarrierId=entityBundle.CarrierId;
                viewBundles.Add(model);
            }
            return Json(viewBundles.ToDataSourceResult(request));
    
    }
