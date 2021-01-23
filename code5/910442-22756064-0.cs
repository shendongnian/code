        <Grid x:Name="Gd" Visibility="Visible">
            <Grid.Triggers>
                <EventTrigger>
                    <BeginStoryboard>
                        <Storyboard>
                            <ObjectAnimationUsingKeyFrames Storyboard.TargetName="Gd" Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame Value="Collapsed" KeyTime="0"/>
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Grid.Triggers>
        </Grid>
