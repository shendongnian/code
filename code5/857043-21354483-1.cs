    public ActionResult AddDeveloper(EmployeeViewModel employee)
            {
                AutoMapper.Mapper.CreateMap<EmployeeViewModel, Developer>()
                          .ForMember(destination => destination, option => option.MapFrom(source => source.Developer));
                Developer developer = AutoMapper.Mapper.Map<EmployeeViewModel, Developer>(employee);
            }
