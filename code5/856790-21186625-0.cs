    <ListBox x:Name="messageBox">
        <ListBox.ItemContainerStyle >
            <Style TargetType="ListBoxItem" >
                         <Style.Triggers>
                    <EventTrigger RoutedEvent="Loaded" >
                        <BeginStoryboard>
                            <Storyboard >
                                <ColorAnimation  Storyboard.TargetProperty="Background.Color" From="Red" To="Transparent" />
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
