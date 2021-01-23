    <Style x:Key="characterKeyT" TargetType="{x:Type local:TouchButton}">
        <Setter Property="Focusable" Value="False" />
        <Setter Property="HorizontalContentAlignment" Value="Center"/>
        <Setter Property="VerticalContentAlignment" Value="Center"/>
        <Setter Property="Padding" Value="1"/>
        <Setter Property="Margin" Value="6,4,8,4"/>
        <Setter Property="FontSize" Value="24"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:TouchButton}">
                    <Grid x:Name="grid">
                        <Border x:Name="border" CornerRadius="0">                                
                            <Border.Background>
                                <SolidColorBrush x:Name="BackgroundBrush" Color="{Binding Source={StaticResource settingsProvider}, Path=Default.ThemeColorPaleGray2}"/>
                            </Border.Background>
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center" TextElement.Foreground="Black" 
                                              TextElement.FontSize="24"></ContentPresenter>
                        </Border>
                    </Grid>
                    <ControlTemplate.Resources>
                        <Storyboard x:Key="FadeTimeLine" BeginTime="00:00:00.000" Duration="00:00:02.10">
                            <ColorAnimation Storyboard.TargetName="BackgroundBrush" Storyboard.TargetProperty="Color"                                                 
                                             To="#FF22B0E6" 
                                            Duration="00:00:00.10"/>
                            <ColorAnimation Storyboard.TargetName="BackgroundBrush" Storyboard.TargetProperty="Color"                                                 
                                             To="#FFECE8E8" 
                                            Duration="00:00:02.00"/>
                        </Storyboard>
                    </ControlTemplate.Resources>
                    <ControlTemplate.Triggers>                            
                        <Trigger Property="IsTouched" Value="True">
                            <Trigger.EnterActions>
                                <BeginStoryboard Storyboard="{StaticResource FadeTimeLine}"/>
                            </Trigger.EnterActions>
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="BorderBrush" TargetName="border" Value="{StaticResource ThemeSolidColorBrushPaleGray}"/>
                        </Trigger>
                        <Trigger Property="IsMouseOver" Value="False">
                            <Setter Property="Background" TargetName="border"  Value="{StaticResource ThemeSolidColorBrushPaleGray2}"/>
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="Opacity" TargetName="grid" Value="0.25"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
