    <Grid HorizontalAlignment="Right">
    <Grid.Style>
        <Style TargetType="Grid">
            <Setter Property="Width" Value="0"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding ShowMovieForm}" Value="True">
                    <DataTrigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Duration="0:0:0.1" Storyboard.TargetProperty="Width" To="400" />
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                    <DataTrigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Duration="0:0:0.1" Storyboard.TargetProperty="Width" To="0" />
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.ExitActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Grid.Style>
