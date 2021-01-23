    public partial class Poop_info_page : PhoneApplicationPage
    {
      public Poop_info_page()
      {
        InitializeComponent();
        colorPicker.ItemsSource = ColorExtensions.AccentColors();
        shapePicker.ItemsSource = ShapeData.ShapeNames();
      }
    }
