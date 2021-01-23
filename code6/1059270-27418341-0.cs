    public interface IPreLoad<out T> where T : BaseEntity 
    {
        void Preload();
    }
    
