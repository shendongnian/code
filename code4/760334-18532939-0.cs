    <Grid Background="Red" Opacity="0">
        <Grid.Style>
            <Style TargetType="Grid">
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True" >
                        <Setter Property="Visibility" Value="Hidden"/>
                    </Trigger>
                    <Trigger Property="Visibility" Value="Visible">
                        <Trigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard  >
                                    <DoubleAnimation BeginTime="00:00:00"  Storyboard.TargetProperty="(UIElement.Opacity)" From="0" To="1" Duration="00:00:03"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </Trigger.EnterActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Grid.Style>
     </Grid>
