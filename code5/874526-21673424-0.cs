    public interface IThingOwner<out ThingType> where ThingType : ThingBase { }
    public class ThingOwner<ThingType> : IThingOwner<ThingType>
        where ThingType : ThingBase
    {
        
    }
    IThingOwner<ThingBase> thingOwner = new ThingOwner<ThingA>();
