    public class Action
    {
        public abstract void LoadTexture(...);
    }
    
    // Since static façade class has a generic type parameter, we're talking
    // about a completely different class than just "Action" and both can co-exist!
    public static class Action<TAction> where TAction : Action, new()
    {
        public static Texture2D LoadTexture(...)
        { 
            // Since generic TAction parameter must implement a public parameterless
            // constructor, you may instantiate T like a concrete class:
            return new TAction().LoadTexture(...);
        }
    }
