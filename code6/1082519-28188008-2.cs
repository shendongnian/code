    <Grid x:Name="TiltingGrid" RenderTransformOrigin="0.3, 0.5">
        <Grid.Style>
            <Style TargetType="Grid">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsTilted,
                        RelativeSource={RelativeSource AncestorType=UserControl}}"
                        Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation
                                        Storyboard.TargetProperty="RenderTransform.Angle"
                                        To="45" Duration="0:0:0.2"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation
                                        Storyboard.TargetProperty="RenderTransform.Angle"
                                        To="0" Duration="0:0:0.2"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
        <Grid.RenderTransform>
            <RotateTransform/>
        </Grid.RenderTransform>
        ...
    </Grid>
