    <Window x:Class="Demo.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="650" Width="500"
            xmlns:local="clr-namespace:Demo">
        <Grid>
            <Button Height="40" HorizontalAlignment="Left" IsEnabled="True" IsHitTestVisible="True" Margin="262,219,0,0" Name="home_btn" VerticalAlignment="Top" Width="89">
                <Button.Template>
                    <ControlTemplate TargetType="{x:Type Button}">
                        <Grid>
                            <Image Name="Normal" Source="pause.png" />
                            <Image Name="Hover" Source="play.png" Opacity="0"/>
                            <Image Name="Pressed" Source="pause.png" Opacity="0" />
                        </Grid>
                        <ControlTemplate.Resources>
                            <Storyboard x:Key="MouseDownTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Pressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.05" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="MouseUpTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Pressed" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="0"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="MouseEnterTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Hover" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="MouseExitTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Hover" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="0"/>
                                </DoubleAnimationUsingKeyFrames>
                            </Storyboard>
                        </ControlTemplate.Resources>
                        <ControlTemplate.Triggers>
                            <Trigger Property="ButtonBase.IsPressed" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseDownTimeLine}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseUpTimeLine}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                            <Trigger Property="UIElement.IsMouseOver" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseEnterTimeLine}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource MouseExitTimeLine}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Button.Template>
            </Button>
        </Grid>
    </Window>
