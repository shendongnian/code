    public static class ButtonExt
    {
        #region RectangleBackground Property
        public static readonly DependencyProperty RectangleBackgroundProperty;
        public static void SetRectangleBackground(DependencyObject DepObject, Brush value)
        {
            DepObject.SetValue(RectangleBackgroundProperty, value);
        }
        public static Brush GetRectangleBackground(DependencyObject DepObject)
        {
            return (Brush)DepObject.GetValue(RectangleBackgroundProperty);
        }
        #endregion
        #region RectangleBorderBrush Property
        public static readonly DependencyProperty RectangleBorderBrushProperty;
        public static void SetRectangleBorderBrush(DependencyObject DepObject, Brush value)
        {
            DepObject.SetValue(RectangleBorderBrushProperty, value);
        }
        public static Brush GetRectangleBorderBrush(DependencyObject DepObject)
        {
            return (Brush)DepObject.GetValue(RectangleBorderBrushProperty);
        }
        #endregion       
        #region Button Constructor
        static ButtonExt()
        {
            #region RectangleBackground
            PropertyMetadata BrushPropertyMetadata = new PropertyMetadata(Brushes.Transparent);
            RectangleBackgroundProperty = DependencyProperty.RegisterAttached("RectangleBackground",
                                                                typeof(Brush),
                                                                typeof(ButtonExt),
                                                                BrushPropertyMetadata);
            #endregion
            #region RectangleBorderBrush
            RectangleBorderBrushProperty = DependencyProperty.RegisterAttached("RectangleBorderBrush",
                                                                typeof(Brush),
                                                                typeof(ButtonExt),
                                                                BrushPropertyMetadata);
            #endregion
        }
        #endregion
    }
MainWindow.xaml
    <Window.Resources>
        <Style x:Key="TestButtonExtensionStyle" TargetType="{x:Type Button}">
            <Setter Property="Width" Value="80" />
            <Setter Property="Height" Value="80" />
            <Setter Property="Background" Value="Green" />
            <Setter Property="BorderBrush" Value="Pink" />
            <Setter Property="BorderThickness" Value="4" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Button}">
                        <Border Background="{TemplateBinding Background}" 
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}">
                            <Grid>
                                <Rectangle Fill="{TemplateBinding PropertiesExtension:ButtonExt.RectangleBackground}" 
                                           Stroke="{TemplateBinding PropertiesExtension:ButtonExt.RectangleBorderBrush}"
                                           Width="30" 
                                           Height="30" />
                                <ContentPresenter Content="{TemplateBinding Content}" 
                                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                            </Grid>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    
    <Grid>
        <Button Style="{StaticResource TestButtonExtensionStyle}"
                PropertiesExtension:ButtonExt.RectangleBackground="Aquamarine"
                PropertiesExtension:ButtonExt.RectangleBorderBrush="Black"
                Content="Test" />
    </Grid>
Output
