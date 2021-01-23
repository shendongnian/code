    public class MyClass {
        private _list = new List<object>();  // don't store any type info for now
     
        public void AddDropTarget.... /* this is already correct */
    
        public void RunUiStuff() {
            // get all items that are of type UIElement.  Items of wrong type will be ignored
            foreach(var e in _list.OfType<UIElement>()) {
          
            }
        }
    
        public void RunDropStuff() {
            // cast works as well, but will throw if any object is not the correct type
            foreach(var e in _list.Cast<IDropTarget>()) {
            }
        }
    }
