    public interface IViewModel { }
    public class ViewModelOne : IViewModel { }
    public class ViewModelTwo : IViewModel { }
    public class ViewModelThree : IViewModel { }
    public static class GlobalObjects
    {
        private static ViewModelOne viewModelOne = null;
        public static ViewModelOne ViewModelOne
        {
            get { return Get<ViewModelOne>(ref viewModelOne); }
            set { Set(ref viewModelOne, value); }
        }
        private static T Get<T>(ref T storage) where T : IViewModel, new()
        {
            if (storage != null)
                return storage;
            try
            {
                var json = Load(typeof(T).ToString());
                return storage = Deserialize<T>(json);
            }
            catch (Exception)
            {
                return new T();
            }
        }
        private static void Set<T>(ref T storage, T value) where T : IViewModel
        {
            if (storage?.Equals(value))
                return;
            try
            {
                var json = Serialize(value);
                Save(json, typeof(T).ToString());
            }
            catch (Exception)
            {
                Save(string.Empty, typeof(T).ToString());
            }
        }
        private static void Save(string value, string key)
        {
            throw new NotImplementedException();
        }
        private static string Serialize(object obj)
        {
            throw new NotImplementedException();
        }
        private static string Load(string key)
        {
            throw new NotImplementedException();
        }
        private static T Deserialize<T>(string obj)
        {
            throw new NotImplementedException();
        }
    }
