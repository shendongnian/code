      <Window.Resources>
        <BitmapImage x:Key="imag1" UriSource="image1.jpg"></BitmapImage>
        <BitmapImage x:Key="imag2" UriSource="path.jpg"></BitmapImage>
        <Style TargetType="ToggleButton">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ToggleButton">
                        <Grid x:Name="GD" Background="{TemplateBinding Background}">
                            <ContentPresenter></ContentPresenter>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Setter TargetName="GD" Property="Background">
                                    <Setter.Value>
                                        <ImageBrush ImageSource="{Binding Path=Tag, RelativeSource={RelativeSource AncestorType=ToggleButton}}"></ImageBrush>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <ToggleButton x:Name="sampleTestToggleButton"  Tag="{StaticResource imag2}"  ClickMode="Press"  Grid.Row="4" Grid.Column="3"  BorderBrush="Transparent" Foreground="Transparent">
        <ToggleButton.Background>
            <ImageBrush ImageSource="{StaticResource imag1}"></ImageBrush>
        </ToggleButton.Background>
    </ToggleButton>
