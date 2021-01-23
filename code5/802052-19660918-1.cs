    public static class WindowsExtensions
    {
       public static bool IsOpened(this Window window)
       {
            return Application.Current.Windows.Cast<Window>().Any(x => x.GetHashCode() == window.GetHashCode());
       }
    }
