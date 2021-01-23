         <Grid Height="60" Width="50" Name="content" Background="Transparent" Focusable="True">
        <Grid.Resources>
            <GradientStop x:Name="Stop2" Color="Blue" Offset="1" x:Key="s"></GradientStop>
            <Style TargetType="{x:Type Grid}">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="MouseEnter">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Grid.Background).(SolidColorBrush.Color)">
                                    <EasingColorKeyFrame KeyTime="0" Value="Blue" />
                                </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="GotKeyboardFocus">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Grid.Background).(SolidColorBrush.Color)">
                                    <EasingColorKeyFrame KeyTime="0" Value="Red" />
                                </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="MouseDown">
                        <BeginStoryboard>
                            <Storyboard >
                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Grid.Background).(SolidColorBrush.Color)">
                                    <EasingColorKeyFrame KeyTime="0" Value="Green" />
                                </ColorAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Resources>
        <Grid.RowDefinitions>
            <RowDefinition Height="36"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
        </Grid.RowDefinitions>
        <Image Name="img_door" HorizontalAlignment="Center" VerticalAlignment="Center" Grid.Row="0" Source="/OneCardApp.Ex;component/image/36/companyInfo.png"></Image>
        <Label Name="lbl_name" HorizontalAlignment="Center" VerticalAlignment="Center" Grid.Row="1"></Label>
    </Grid>
