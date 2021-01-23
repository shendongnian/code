    protected void Application_Start()
    {
            //Usually in a diff class Mapping.ConfigureDataTransferObjects();
            Mapper.CreateMap<MyEntity, ObjectDTO>();
            Mapper.CreateMap<ObjectDTO, MyEntity>();
    }
