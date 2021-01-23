    public sealed partial class Module<T, U> : IModule<T, U>
      where T : BaseBox
      where U : BaseItem
    {
        private T _box;
        public Module(T box)
        {
            _box = box;
        }
        U[] IModule<T, U>.GetItems<T>( int id )
        {
            // You need to determine how id relates to _box.
            return _box.Unboxing();
        }
    }
