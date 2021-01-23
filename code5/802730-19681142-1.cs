    <Style x:Key="CircleButton" TargetType="Button">
        <Setter Property="Background" Value="Blue"/>
        <Style.Triggers>
            <DataTrigger Binding="{Binding RiskHighLowMedium}" Value="True">
                <Setter Property="Button.Background" Value="Red" />
            </DataTrigger>
        </Style.Triggers>
    </Style>
    ...
    <Button Width="50" Height="50" Style="{StaticResource CircleButton}" 
        Click="Button_Click">
        <Button.Template>
            <ControlTemplate>
                <Border Background="{TemplateBinding Background}">
                    <ContentPresenter />
                </Border>
            </ControlTemplate>
        </Button.Template>
    </Button>
    ...
    bool _highLow = false;
    public bool RiskHighLowMedium
    {
        get { return _highLow; }
        set { _highLow = value; OnPropertyChanged("RiskHighLowMedium"); }
    }
    ...
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        RiskHighLowMedium = true;
    }
