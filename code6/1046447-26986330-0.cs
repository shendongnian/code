    /** Based on same interfaces originally provided... and the classes that implement them **/
    public class ClassOne : IMoveable
    {
        public void MoveMethod() { ... }
    }
    
    public class ClassTwo: ClassOne, IKilleable
    {
        // Move Method is inherited from ClassOne, THEN you have added IKilleable
        public void KillMethod() { ... }
    }
    
    public class ClassThree: ClassOne, IRenderable
    {
        // Similar inherits the MoveMethod, but adds renderable
        public void RenderMethod() { ... }
    }
    
    public class ClassFour: ClassTwo, IRenderable
    {
        // Retains inheritance of Move/Kill, but need to add renderable
        public void RenderMethod() { ... }
    }
