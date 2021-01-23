    using Android.App;
    using Android.OS;
    using Android.Support.V4.App;
    // using Fragment = Android.Support.V4.App.Fragment;
    namespace com.xamarin.recipes.filepicker
    {
        [Activity(Label = "Choose file", MainLauncher = true, Icon = "@drawable/icon")]
        public class FilePickerActivity : FragmentActivity
        {
            // use Android.Support.V4.App.Fragment below
            private FileListFragment mFileListFragment; 
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.ChooseAudio);
                mFileListFragment = (FileListFragment)SupportFragmentManager.FindFragmentById(Resource.Id.fileListFragment);
                // Avoid any confusion: change its id in your layout by "fileListFragment"
            }
        }
    }   
