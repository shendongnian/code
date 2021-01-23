    <Window.Resources>
        <Style x:Key="toggleBtnStyle" TargetType="{x:Type ToggleButton}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Path=myProperty}" Value="true">
                    <Setter Property="Content" Value="IS TRUE"/>
                </DataTrigger>
                <DataTrigger Binding="{Binding Path=myProperty}" Value="false">
                    <Setter Property="Content" Value="IS FALSE"/>
                </DataTrigger>
            </Style.Triggers>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ToggleButton}">
                        <Border BorderThickness="1,1,1,1" CornerRadius="1,1,1,1" BorderBrush="Black" Background="Black" >
                            <Grid>
                                <Border x:Name="BorderUp" BorderThickness="1,1,1,1" CornerRadius="1,1,1,1" Background="Blue"/>
                                <Border x:Name="BorderDown" BorderThickness="1,1,1,1" CornerRadius="1,1,1,1" Opacity="0" Background="Aqua"/>
                                <ContentPresenter x:Name="Contents" HorizontalAlignment="Center" VerticalAlignment="Center" Width="Auto" Margin="0,0,0,0"/>
                            </Grid>
                        </Border>
                        <ControlTemplate.Resources>
                            <Storyboard x:Key="ButtonDownTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="BorderDown" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.05" Value="1"/>
                                </DoubleAnimationUsingKeyFrames>
                                <ThicknessAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Contents" Storyboard.TargetProperty="Margin">
                                    <SplineThicknessKeyFrame KeyTime="00:00:00.025" Value="0.5,0.5,0,0"/>
                                </ThicknessAnimationUsingKeyFrames>
                            </Storyboard>
                            <Storyboard x:Key="ButtonUpTimeLine">
                                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="BorderDown" Storyboard.TargetProperty="Opacity">
                                    <SplineDoubleKeyFrame KeyTime="00:00:00.25" Value="0"/>
                                </DoubleAnimationUsingKeyFrames>
                                <ThicknessAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Contents" Storyboard.TargetProperty="Margin">
                                    <SplineThicknessKeyFrame KeyTime="00:00:00.25" Value="0,0,0,0"/>
                                </ThicknessAnimationUsingKeyFrames>
                            </Storyboard>
                        </ControlTemplate.Resources>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard Storyboard="{StaticResource ButtonDownTimeLine}"/>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard Storyboard="{StaticResource ButtonUpTimeLine}"/>
                                </Trigger.ExitActions>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
