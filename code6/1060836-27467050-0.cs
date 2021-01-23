     <Style TargetType="{x:Type Button}">
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Trigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation From="1" To="0.8" RepeatBehavior="Forever" AutoReverse="True" Duration="00:00:00.3" Storyboard.TargetProperty="RenderTransform.ScaleX" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.EnterActions>
                    <Trigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation To="1" Duration="00:00:00.4" Storyboard.TargetProperty="RenderTransform.ScaleX" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.ExitActions>
                </Trigger>
            </Style.Triggers>
            <Setter Property="RenderTransform">
                <Setter.Value>
                    <ScaleTransform CenterX="120" CenterY="30" ScaleX="1" />
                </Setter.Value>
            </Setter>
        </Style>
