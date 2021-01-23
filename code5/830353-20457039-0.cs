    var anonymous = new { 
      Menu = unitOfWork.MenuRepository.GetById(Id);, 
      Documents = unitOfWork.DocumentRepository.GetBy(x => x.MenuID ==  menu.MenuID).ToList(); 
    };
      var sectionModel = AutoMapper.Mapper.DynamicMap<SectionModel>(anonymous);
