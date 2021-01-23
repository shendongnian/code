    <UserControl ...>
        <Grid>
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup>
                    <VisualState x:Name="TiltedState">
                        <Storyboard>
                            <DoubleAnimation
                                Storyboard.TargetName="TiltingGrid"
                                Storyboard.TargetProperty="RenderTransform.Angle"
                                To="45" Duration="0:0:0.2"/>
                        </Storyboard>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateManager.VisualStateGroups>
            <Grid x:Name="TiltingGrid" RenderTransformOrigin="0.3, 0.5">
                <Grid.RenderTransform>
                    <RotateTransform/>
                </Grid.RenderTransform>
                ...
            </Grid>
        </Grid>
    </UserControl>
