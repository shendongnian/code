        <Style x:Key="FlashingImageStyle" TargetType="{x:Type Image}">
            <Style.Triggers>
                <Trigger Property="Visibility" Value="Visible">
                    <Trigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation
                                      Storyboard.TargetProperty="Opacity"
                                      From="1.0" To="0.1" Duration="0:0:0.5"
                                      AutoReverse="True" RepeatBehavior="0:0:2" />
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.EnterActions>
                </Trigger>
            </Style.Triggers>
        </Style>
