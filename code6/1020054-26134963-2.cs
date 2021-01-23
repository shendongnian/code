      // I've added "I" since it's an Interface
      public interface IMenuElement {
        void AddMenuElement(MenuElement menuToAdd);
        void RemoveMenuElement(MenuElement menuToRemove);
        void Activate();
    
        // I've changed your 
        // MenuElement GetMenuElement(int index)
        // to indexer
        MenuElement this[int index] {get;}
        
        // Event of interest; I've renamed it from onActivate
        event EventHandler Activated;
      }
    
      ...
      // Possible interface implementation
      public class MyMenuElement: IMenuElement {
        ...
        // name like "onActivate" is better to use here, as a private context
        private void onActivated() {
          if (Object.ReferenceEquals(null, Activated)) 
            return;
    
          Activated(this, EventArgs.Empty);
        }
        public void Activate() {
          // Some staff here
          ... 
          // Raising the event
          onActivated();
        }
      }
