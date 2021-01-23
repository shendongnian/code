    _quatationRepository = new QuatationRepository();
    IList<Quatation> quatationObj = _quatationRepository.GetAll(quatation => quatation.IsDeleted == 0);
    IList<QuatationModel> quatationModelObj = new List<QuatationModel>();
    
    AutoMapper.Mapper.CreateMap<Quatation, QuatationModel>(qm);
    quatationModelObj = AutoMapper.Mapper.Map(quatationObj, quatationModelObj);
    return quatationModelObj;
