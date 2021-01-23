    public class AEntity : Entity { }
    
    public class BEntity : Entity { }
    public class AViewModel : ViewModel { }
    
    public class BViewModel : ViewModel { }
    Mapper.CreateMap<Entity, ViewModel>()
        .Include<AEntity, AViewModel>()
        .Include<BEntity, BViewModel>();
    // Then map AEntity and BEntity as well.
