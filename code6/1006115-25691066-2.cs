    public interface ILoadExt: ILoad
    {
        IList<Measure> ConvertToMeasure();
    }
    
    
    public class AExt : A, ILoadExt
    {
         public List<Measure> ConvertToMeasure()
         {
             return some List<Measure>
         }
    }
    
    public class BExt : B, ILoadExt
    {
         public List<Measure> ConvertToMeasure()
         {
             return some List<Measure>
         }
    }
