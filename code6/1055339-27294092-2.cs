    public abstract class Behavior<T> : DependencyObject, IBehavior where T : DependencyObject {
 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public T AssociatedObject { get; set; }
 
        protected virtual void OnAttached() {
        }
 
        protected virtual void OnDetaching() {
        }
 
        public void Attach(Windows.UI.Xaml.DependencyObject associatedObject) {
            this.AssociatedObject = (T)associatedObject;
            OnAttached();
        }
 
        public void Detach() {
            OnDetaching();
        }
 
        DependencyObject IBehavior.AssociatedObject {
            get { return this.AssociatedObject; }
        }
    }
