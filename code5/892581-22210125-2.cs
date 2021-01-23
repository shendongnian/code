    <Style x:Key="ReverseMenuItemButtonStyle" TargetType="Button">
        <Setter Property="FontSize" Value="60" />
        <Setter Property="FontFamily" Value="Segoe" />
        <Setter Property="FontWeight" Value="UltraLight" />
        <Setter Property="Foreground" Value="#FFEBEDEA" />
        <Setter Property="HorizontalContentAlignment" Value="Right" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <ControlTemplate.Triggers>
                        <EventTrigger RoutedEvent="Button.Click">
                            <EventTrigger.Actions>
                                <BeginStoryboard>
                                    <Storyboard Name="themeUnselectionAnimation">
                                        <DoubleAnimation 
                                            Storyboard.TargetName="coloredRectangle"
                                            Storyboard.TargetProperty="Width"
                                            From="30.0" 
                                            To="250.0" 
                                            Duration="0:0:0.3" />
                                    </Storyboard>
                                </BeginStoryboard>                                    
                            </EventTrigger.Actions>
                        </EventTrigger>
                    </ControlTemplate.Triggers>
                    ...
                </ControlTemplate>                    
            </Setter.Value>
        </Setter>             
    </Style>
