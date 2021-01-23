    public abstract class ViewBase<T> {
        public abstract T SomeParam { get; }
        public static implicit operator T(ViewBase<T> view) {
            return view.SomeParam;
        }
    }
