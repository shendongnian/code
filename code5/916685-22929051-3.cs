XAML
    <DataTemplate x:Key="ImageGalleryDataTemplate">
        <Grid>
            <Border Name="MyBorder" BorderBrush="#FFFF9800" BorderThickness="1" Width="120" Height="120" Padding="5" Margin="5" CornerRadius="6">
                <Image Name="MyImage" Tag="{Binding Path=Flag}" Source="{Binding Path=ImagePath}" Stretch="Fill" HorizontalAlignment="Center">
                    <Image.ToolTip>
                        <Grid>
                            <Image Source="{Binding Path=ImagePath}" Stretch="Fill" HorizontalAlignment="Center" Height="200" Width="200" />
                        </Grid>
                    </Image.ToolTip>
                </Image>
            </Border>
        </Grid>
            
        <DataTemplate.Triggers>
            <DataTrigger Binding="{Binding Path=Tag, ElementName=MyImage}" Value="True">
                <Setter TargetName="MyBorder" Property="BorderBrush" Value="Red" />
            </DataTrigger>
            <DataTrigger Binding="{Binding Path=Tag, ElementName=MyImage}" Value="False">
                <Setter TargetName="MyBorder" Property="BorderBrush" Value="Green" />
            </DataTrigger>
        </DataTemplate.Triggers>
    </DataTemplate>
Code-behind
    public partial class MainWindow : Window
    {
        int imageNumber = 0;
        public List<MyImage> ImagePath = new List<MyImage>();
        public MainWindow()
        {
            InitializeComponent();
            lb_Images.ItemsSource = ImagePath;
        }
        private void bu_addImage_Click(object sender, RoutedEventArgs e)
        {
            addImageToListBox();
        }
        private void addImageToListBox()
        {
            imageNumber++;
            if (imageNumber == 4) imageNumber = 0;
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            // load input image
            string ImageFilename = directoryPath + "img";
            ImageFilename += imageNumber.ToString();
            ImageFilename += ".jpg";
            ImagePath.Add(new MyImage 
                          { 
                              ImagePath = ImageFilename, 
                              Flag = false 
                          }); 
            lb_Images.Items.Refresh();
        }
    }
    public class MyImage
    {
        public string ImagePath
        {
            get; 
            set; 
        }
        public bool Flag
        { 
            get;
            set;
        }
    }
