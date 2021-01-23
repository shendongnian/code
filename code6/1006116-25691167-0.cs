    List<ILoad> list = new List<ILoad>();
    list = GetALlIloads();
    Factory f = new Factory();
    foreach (var item in list)
    {
        dynamic concreteType = item;
        var converted = f.ConvertToMeasure(concreteType );
    }
    public class A: Iload
    {
      // something
    } 
    publicclass B: ILoad
    {
       //Something
    }
    public class Factory
    {
        public List<Measure> ConvertToMeausre(A model)
        {
            return some List<Measure>
        }
        public List<Measure> ConvertToMeausre(B model)
        {
            return some List<Measure>
        }
    }
