    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Storage;
    using Windows.Storage.AccessCache;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    
    namespace test
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
    	{
    		ObservableCollection<Note> noteslist = new ObservableCollection<Note>();
    
    		public class Note
    		{
    			public StorageFile file { get; set; }
    			public string name { get; set; }
    		}
            public MainPage()
            {
                this.InitializeComponent();
            }
    
    
    		protected async override void OnNavigatedTo(NavigationEventArgs e)
    		{
    			var opener = new Windows.Storage.Pickers.FolderPicker();
    			opener.FileTypeFilter.Add(".txt");
    
    			StorageFolder folder = await opener.PickSingleFolderAsync();
    
    			if(folder != null)
    			{
    				StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
    
    				// Got it.
    				IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
    
    				if(files != null)
    				{
    					foreach(StorageFile f in files)
    					{
    						noteslist.Add(new Note()
    							{
    								name = f.DisplayName,
    								file = f
    							});
    
    					}
    
    					list.ItemsSource = noteslist;
    				}
    			}
    		}
        }
    }
