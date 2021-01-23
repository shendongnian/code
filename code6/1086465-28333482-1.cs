     <ToggleButton Name="Toggle" Width="40" Height="40" >
                <ToggleButton.Triggers>
                    <EventTrigger RoutedEvent="ToggleButton.Click" >
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation By="1" Duration="00:00:00" Storyboard.TargetName="slValue" Storyboard.TargetProperty="Value"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </ToggleButton.Triggers>
            </ToggleButton>
