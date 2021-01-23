    <Button Content="" Name="up" Template="{DynamicResource BackgroundButton}" >
            <Button.Background>
                <ImageBrush ImageSource="image.png" />
            </Button.Background>
            <Button.Resources>
                <ControlTemplate x:Key="BackgroundButton" TargetType="Button">
                    <Border Name="border" BorderThickness="1" BorderBrush="Black" Background="{TemplateBinding Background}">
                        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" />
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" TargetName="border">
                                <Setter.Value>
                                    <ImageBrush ImageSource="image.png" Opacity="0.5" />
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Button.Resources>
        </Button>
