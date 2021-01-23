    public interface IPreLoad
    {
        void Preload();
    }
    
    public interface IPreLoad<T>: IPreload where T : BaseEntity 
    {
       // your other typed methods...
    }
