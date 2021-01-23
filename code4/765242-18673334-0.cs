    public interface ILibrary<T,V> where T:ILiBelement<T,V> where T:ILiBelement<T,V> 
        where V:IVersion<V>
    {
    }
    interface ILiBelement<T,V> where V:IVersion<T>
    {
    }
    interface IVersion<T>
    {
    
    }
