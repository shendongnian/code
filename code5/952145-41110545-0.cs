    Grid Name="YourGrid">
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
                                <Storyboard Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)">
                                    <DoubleAnimation To="0.7" Duration="0" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <BeginStoryboard>
                                <Storyboard Storyboard.TargetProperty="Background.(SolidColorBrush.Opacity)">
                                    <DoubleAnimation To="0.2" Duration="0" />
                                </Storyboard>
                            </BeginStoryboard>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
    </Grid>
