    _quatationRepository = new QuatationRepository();
    IList<Quatation> quatationObj = _quatationRepository.GetAll(quatation => quatation.IsDeleted == 0);
    IList<QuatationModel> quatationModelObj = new List<QuatationModel>();
    
    AutoMapper.Mapper.CreateMap<IList<Quatation>, IList<QuatationModel>>();
    quatationModelObj = AutoMapper.Mapper.Map<IList<Quatation>, IList<QuatationModel>>(quatationObj.ToList());
    return quatationModelObj;
