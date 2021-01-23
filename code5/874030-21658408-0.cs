    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    
    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
    		protected override async void OnNavigatedTo(NavigationEventArgs e)
    		{
    			FileOpenPicker opener = new FileOpenPicker();
    			opener.ViewMode = PickerViewMode.Thumbnail;
    			opener.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    			opener.FileTypeFilter.Add(".jpg");
    			opener.FileTypeFilter.Add(".jpeg");
    			opener.FileTypeFilter.Add(".png");
    
    			StorageFile file = await opener.PickSingleFileAsync();
    			if (file != null)
    			{
    				// We've now got the file. Do something with it.
    				var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
    				var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
    				await bitmapImage.SetSourceAsync(stream);
    				bustin.Source = bitmapImage;
    				var decoder = await Windows.Graphics.Imaging.BitmapDecoder.CreateAsync(stream);
    			}
    			else
    			{
    				//OutputTextBlock.Text = "The operation may have been cancelled.";
    			}
    
    		}
        }
    }
