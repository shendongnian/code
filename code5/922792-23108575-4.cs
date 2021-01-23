     <Storyboard FillBehavior="Stop" x:Key="FadeOut">
            <DoubleAnimation FillBehavior="Stop" Storyboard.TargetName="ScreensaverImage" Storyboard.TargetProperty="Opacity" From="0.05" To="1" Duration="0:0:2">
            </DoubleAnimation>
      </Storyboard>
     <Storyboard FillBehavior="Stop" x:Key="FadeIn">
            <DoubleAnimation Storyboard.TargetName="ScreensaverImage" FillBehavior="Stop" Storyboard.TargetProperty="Opacity"  From="1" To=".05" Duration="0:0:2">
            </DoubleAnimation>
      </Storyboard>
    <Grid>
        <Image x:Name="ScreensaverImage"></Image>
    </Grid>
    public partial class MainWindow : Window
    {
        List<Uri> savedImage = new List<Uri>();
        int i = 0;
        Storyboard fadeIn, fadeOut;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            savedImage.Add(new Uri("image1.png", UriKind.Relative));
            savedImage.Add(new Uri("image2.png", UriKind.Relative));
            savedImage.Add(new Uri("image3.png", UriKind.Relative));
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (savedImage.Count > 0)
            {
                fadeIn = (Storyboard)this.Resources["FadeIn"];
                fadeOut = (Storyboard)this.Resources["FadeOut"];
                fadeIn.Completed += fadeIn_Completed;
                fadeOut.Completed += fadeOut_Completed;
                ScreensaverImage.Source = new BitmapImage(savedImage[i++]);
                if (savedImage.Count > 1)
                {
                    BeginStoryboard(fadeOut);
                }
                ScreensaverImage.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ScreensaverImage.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        void fadeOut_Completed(object sender, EventArgs e)
        {
            fadeIn.Begin();
        }
        void fadeIn_Completed(object sender, EventArgs e)
        {
            if (i == savedImage.Count)
                i = 0;
            ScreensaverImage.Source = new BitmapImage(savedImage[i++]);
            fadeOut.Begin();
        }
    }
