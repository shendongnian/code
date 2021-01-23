    public abstract class MenuElement
    {
        public delegate void MenuEvent();
        event MenuEvent onActivate;
    
        abstract virtual void AddMenuElement( MenuElement menuToAdd );
        abstract virtual void Activate();
    }
