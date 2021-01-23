    <i:Interaction.Behaviors>
        <!--#Region EnterActions-->
            <c:DataTriggerBehavior Binding="{Binding Path=IsInBubbleGroup}" Value="True">
                <m:ControlStoryboardAction ControlStoryboardOption="Play">
                    <m:ControlStoryboardAction.Storyboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleX)" Duration="0:0:0.2" To="1.1">
                                <DoubleAnimation.EasingFunction>
                                    <CubicEase EasingMode="EaseInOut" />
                                </DoubleAnimation.EasingFunction>
                            </DoubleAnimation>
                            <DoubleAnimation Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleY)" Duration="0:0:0.2" To="1.1">
                                <DoubleAnimation.EasingFunction>
                                    <CubicEase EasingMode="EaseInOut" />
                                </DoubleAnimation.EasingFunction>
                            </DoubleAnimation>
                        </Storyboard>
                    </m:ControlStoryboardAction.Storyboard>
                </m:ControlStoryboardAction>
            </c:DataTriggerBehavior>
            <!--#EndRegion EnterActions-->
            <!--#Region ExitActions-->
            <c:DataTriggerBehavior Binding="{Binding Path=IsInBubbleGroup}" Value="False">
                <m:ControlStoryboardAction ControlStoryboardOption="Stop">
                    <m:ControlStoryboardAction.Storyboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleX)" Duration="0:0:0.1" To="1">
                                <DoubleAnimation.EasingFunction>
                                    <CubicEase EasingMode="EaseInOut" />
                                </DoubleAnimation.EasingFunction>
                            </DoubleAnimation>
                            <DoubleAnimation Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleY)" Duration="0:0:0.1" To="1">
                                <DoubleAnimation.EasingFunction>
                                    <CubicEase EasingMode="EaseInOut" />
                                </DoubleAnimation.EasingFunction>
                            </DoubleAnimation>
                        </Storyboard>
                    </m:ControlStoryboardAction.Storyboard>
                </m:ControlStoryboardAction>
            </c:DataTriggerBehavior>
        <!--#EndRegion ExitActions-->
    </i:Interaction.Behaviors>
