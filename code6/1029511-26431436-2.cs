    <Grid x:Name="grdMain" Background="Black">
      <Grid.Triggers>
         <EventTrigger RoutedEvent="Control.MouseEnter">
                <BeginStoryboard>
                    <Storyboard TargetName="grdControls">
                        <DoubleAnimation Duration="0:0:1" To="40" 
                                         Storyboard.TargetProperty="Height"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="Control.MouseLeave">
                <BeginStoryboard>
                    <Storyboard TargetName="grdControls">
                        <DoubleAnimation Duration="0:0:1" To="0" 
                                         Storyboard.TargetProperty="Height"/>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
      </Grid.Triggers>
      <!-- remaining code -->
    </Grid>
