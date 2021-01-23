    <Grid Name="YourGrid">
        <Grid.Background>
            <SolidColorBrush Color="Green" Opacity="0.2" />
        </Grid.Background>
        <Grid.Style>
            <Style TargetType="{x:Type Grid}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsMouseOver, ElementName=YourGrid}" 
                        Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames 
    Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)">
                                        <LinearDoubleKeyFrame Value="0.7" KeyTime="0:0:0"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames 
    Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)">
                                        <LinearDoubleKeyFrame Value="0.2" KeyTime="0:0:0"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
    </Grid>
