    <Trigger Property="IsPressed" Value="True">
        <Trigger.EnterActions>
            <StopStoryboard BeginStoryboardName="MouseOverStoryBoard" />
            <StopStoryboard BeginStoryboardName="MouseOverStoryBoard2" />
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="backgroundBrush" Storyboard.TargetProperty="Color" To="{StaticResource pressedBackgroundColor}" Duration="0:0:0.2" />
                </Storyboard>
            </BeginStoryboard>
        </Trigger.EnterActions>
        <Trigger.ExitActions>
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="backgroundBrush" Storyboard.TargetProperty="Color" To="{StaticResource backgroundColor}" Duration="0:0:0.2" />
                </Storyboard>
            </BeginStoryboard>
        </Trigger.ExitActions>
    </Trigger>
    <Trigger Property="IsMouseOver" Value="True">
        <Trigger.EnterActions>
            <BeginStoryboard Name="MouseOverStoryBoard">
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="backgroundBrush" Storyboard.TargetProperty="Color" To="{StaticResource hoverBackgroundColor}" Duration="0:0:0.2" />
                </Storyboard>
            </BeginStoryboard>
        </Trigger.EnterActions>
        <Trigger.ExitActions>
            <BeginStoryboard Name="MouseOverStoryBoard2">
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="backgroundBrush" Storyboard.TargetProperty="Color" To="{StaticResource backgroundColor}" Duration="0:0:0.2" />
                </Storyboard>
            </BeginStoryboard>
        </Trigger.ExitActions>
    </Trigger>
