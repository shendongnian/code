    public class MetadataNavigationSettingsHelper
    {
        public static void SetHideFoldersNode(MetadataNavigationSettings settings,bool value)
        {
            var t = settings.GetType();
            t.InvokeMember("HideFoldersNode", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, settings, new object[] { value });
        }
    }
