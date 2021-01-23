    public interface IInitializable<TParent> { }
    public class SceneSystemJob<TItem>  
        where TItem : IInitializable<SceneSystemJob<TItem>>
    { }
    public class GameObject : SceneSystemJob<Component> { } // Error here
    public class Component : IInitializable<GameObject> { }
