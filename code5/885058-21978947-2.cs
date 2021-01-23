    <Window.Resources>
        <SolidColorBrush x:Key="GotFocusColor" Color="Green" />
        <SolidColorBrush x:Key="LostFocusColor" Color="Transparent" />
        
        <Style TargetType="{x:Type DataGridRow}">
            <Setter Property="Foreground" Value="#FFB3B3B3"/>
            <Setter Property="Height" Value="25"/>
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            
            <Style.Triggers>
                <Trigger Property="IsSelected" Value="True">
                    <Setter Property="Background" Value="#FF262626"/>
                </Trigger>
                
                <Trigger Property="ItemsControl.AlternationIndex" Value="0">
                    <Setter Property="Background" Value="#FF383838"/>
                </Trigger>
                
                <Trigger Property="ItemsControl.AlternationIndex" Value="1">
                    <Setter Property="Background" Value="#FF333333"/>
                </Trigger>
                <EventTrigger RoutedEvent="DataGrid.GotFocus">
                    <BeginStoryboard>
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{StaticResource GotFocusColor}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
                
                <EventTrigger RoutedEvent="DataGrid.LostFocus">
                    <BeginStoryboard>
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background">
                                <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{StaticResource LostFocusColor}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
