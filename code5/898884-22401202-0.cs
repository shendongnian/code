    public interface ISeedHolder
    {
        int Seed {get;set;}
    }
    
    public class ModelUpdatingRecorder : IRecorder
    {
        int seed;
    
        public ModelUpdatingRecorder(ISeedHolder seedHolder)
        {
            this.seed = seedHolder.Seed;
        }
