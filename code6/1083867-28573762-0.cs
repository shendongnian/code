    public interface IBlackBox
    public interface IBlackBox<T> : IBlackBox {
      Func<T> GetValue;
    }
    public interface IBox { }
    public interface IBox<T> : IBlackBox<T>, IBox { }
    public interface IWrappedBox { }
    public interface IWrappedBox<T> : IBox<IBlackBox<T>>, IWrappedBox { }
    
    public interface IEmptyBox { }
    public static class EmptyBox {
      public static EmptyBox<T> Get<T>() {
        return EmptyBox<T>.value;
      }
      sealed class EmptyBox<T> : IBlackBox<T>, IEmptyBox {
        public static readonly EmptyBox<T> value = new EmptyBox<T>();
        public Func<T> GetValue {
          get {
            throw new NotSupportedException
              ("Cannot extract a value from an empty box.");
          }
        }
      }
    }
