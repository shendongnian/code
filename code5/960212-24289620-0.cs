    <Grid Name="mainGrid" Width="40" xmlns:local="clr-namespace:local">
        <Grid.Resources>
            <local:Plus10Converter x:Key="Plus10Converter"/>    
        </Grid.Resources>
        <Button>
            <Button.Triggers>
                <EventTrigger RoutedEvent="Button.Click">
                    <EventTrigger.Actions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="mainGrid" Storyboard.TargetProperty="Width" Duration="00:00:00.5" 
                                                 From="{Binding ElementName=mainGrid, Path=ActualWidth}" 
                                                 To="{Binding ElementName=mainGrid, Path=ActualWidth, Converter={StaticResource Plus10Converter}}"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger.Actions>
                </EventTrigger>
            </Button.Triggers>
        </Button>
    </Grid>
