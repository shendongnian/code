      <BitmapImage x:Key="ImageSource" UriSource="DefaultImage.png"/>
        <BitmapImage x:Key="MouseOverImage" UriSource="MouseOverImage.png"/>
        <BitmapImage x:Key="MousePressed" UriSource="MousePressed.png"/>
        <Style x:Key="BtnStyle" TargetType="Button">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Grid x:Name="Gd">
                            <Grid.Background>
                                <ImageBrush ImageSource="{StaticResource ResourceKey= ImageSource}" Stretch="Fill"></ImageBrush>
                            </Grid.Background>
                            <ContentPresenter></ContentPresenter>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="Button.IsMouseOver" Value="True">
                                <Setter Property="Background" TargetName="Gd">
                                    <Setter.Value>
                                        <ImageBrush ImageSource="{StaticResource ResourceKey= MouseOverImage}" Stretch="Fill"></ImageBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property="Button.Pressed" Value="False">
                                <Setter Property="Background" TargetName="Gd">
                                    <Setter.Value>
                                        <ImageBrush ImageSource="{StaticResource ResourceKey= MousePressed}" Stretch="Fill"></ImageBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    <Button Style="{StaticResource BtnStyle}" Height="100" Width="300"/>
