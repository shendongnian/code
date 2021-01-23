    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Graphics.Display;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using SDKTemplateCS;
    using Expression.Blend.SampleData.SampleDataSource;
    
    namespace ListViewSimple
    {
        public sealed partial class ScenarioOutput1 : Page
        {
            // A pointer back to the main page which is used to gain access to the input and output frames and their content.
            MainPage rootPage = null;
            StoreData storeData = null;
            private Item item;
            private Expression.Blend.SampleData.SampleDataSource.ItemCollection _collectionNew = new Expression.Blend.SampleData.SampleDataSource.ItemCollection();
            public ScenarioOutput1()
            {
                InitializeComponent();
    
                storeData = new StoreData();
                ItemGridView.ItemsSource = storeData.Collection;
            }
    
            #region Template-Related Code - Do not remove
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                // Get a pointer to our main page.
                rootPage = e.Parameter as MainPage;
    
                // We want to be notified with the OutputFrame is loaded so we can get to the content.
                rootPage.InputFrameLoaded += new System.EventHandler(rootPage_InputFrameLoaded);
            }
    
            protected override void OnNavigatedFrom(NavigationEventArgs e)
            {
                rootPage.InputFrameLoaded -= new System.EventHandler(rootPage_InputFrameLoaded);
            }
            #endregion
    
            #region Use this code if you need access to elements in the input frame - otherwise delete
            void rootPage_InputFrameLoaded(object sender, object e)
            {
                // At this point, we know that the Input Frame has been loaded and we can go ahead
                // and reference elements in the page contained in the Input Frame.
    
                // Get a pointer to the content within the IntputFrame.
                Page inputFrame = (Page)rootPage.InputFrame.Content;
    
                // Go find the elements that we need for this scenario
                // ex: flipView1 = inputFrame.FindName("FlipView1") as FlipView;
            }
            #endregion
    
            Uri _baseUri = new Uri("ms-appx:///");
            private DispatcherTimer _timer;
            private async void Grid_Tapped(object sender, TappedRoutedEventArgs e)
            {
                try
                {
                    item = new Item();
                    item.Title = "This is a new One First";
                    item.SetImage(_baseUri, "SampleData/Images/60SprinklesRainbow.png");
                    item.Subtitle = "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est";
                    item.Link = "http://www.blueyonderairlines.com/";
                    item.Category = "Ice Cream";
                    item.Description = "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac";
                    item.Content = "aaaA";
    
                    _collectionNew.Add(item);
    
                    item = new Item();
                    item.Title = "This is a new One Second";
                    item.Subtitle = "Ultrices rutrum sapien vehicula semper lorem volutpat sociis sit maecenas praesent taciti magna nunc odio orci vel tellus nam sed accumsan iaculis dis est";
                    item.Link = "http://www.blueyonderairlines.com/";
                    item.Category = "Ice Cream";
                    item.SetImage(_baseUri, "SampleData/Images/60SprinklesRainbow.png");
                    item.Description = "Consectetuer lacinia vestibulum tristique sit adipiscing laoreet fusce nibh suspendisse natoque placerat pulvinar ultricies condimentum scelerisque nisi ullamcorper nisl parturient vel suspendisse nam venenatis nunc lorem sed dis sagittis pellentesque luctus sollicitudin morbi posuere vestibulum potenti magnis pellentesque vulputate mattis mauris mollis consectetuer pellentesque pretium montes vestibulum condimentum nulla adipiscing sollicitudin scelerisque ullamcorper pellentesque odio orci rhoncus pede sodales suspendisse parturient viverra curabitur proin aliquam integer augue quam condimentum quisque senectus quis urna scelerisque nostra phasellus ullamcorper cras duis suspendisse sociosqu dolor vestibulum condimentum consectetuer vivamus est fames felis suscipit hac";
                    item.Content = "aaaa";
    
                    _collectionNew.Add(item);
                    scroller.ScrollToHorizontalOffset(2000);
                    _timer = new DispatcherTimer();
                    _timer.Interval = new TimeSpan(3000);
                    _timer.Tick += _timer_Tick;
                    _timer.Start();
    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            void _timer_Tick(object sender, object e)
            {
                ItemGridView.ItemsSource = null;
                ItemGridView.ItemsSource = _collectionNew;
                     _timer.Stop();
            }
        }
    
    
    }
