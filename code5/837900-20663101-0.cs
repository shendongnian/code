                <ControlTemplate.Triggers>
                    <EventTrigger RoutedEvent="MouseEnter">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimation
                                    Storyboard.TargetName="ExpanderBackgroundColor"
                                    Storyboard.TargetProperty="Color"
                                    To="LightBlue"
                                    Duration="0:0:0.1"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    <EventTrigger RoutedEvent="MouseLeave">
                        <BeginStoryboard>
                            <Storyboard>
                                <ColorAnimation
                                    Storyboard.TargetName="ExpanderBackgroundColor"
                                    Storyboard.TargetProperty="Color"
                                    To="White"
                                    Duration="0:0:0.1"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                    
                    <Trigger Property="IsExpanded" Value="True">
                        <Setter TargetName="ContentRow" Property="Height" Value="{Binding ElementName=Content, Path=Height}" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
