    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="CommonStates">
            <VisualStateGroup.Transitions>
                <VisualTransition To="ThankYou" GeneratedDuration="0:0:0.3">
                    <Storyboard Duration="0:0:0.3">
                        <ObjectAnimationUsingKeyFrames Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Visibility)">
                            <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{x:Static Visibility.Visible}"/>
                        </ObjectAnimationUsingKeyFrames>
                        <DoubleAnimation Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Opacity)" To="1" />
                    </Storyboard>
                </VisualTransition>
            </VisualStateGroup.Transitions>
            <VisualState x:Name="Normal">
                <Storyboard Duration="0:0:0.3">
                    <ObjectAnimationUsingKeyFrames Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Visibility)">
                        <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{x:Static Visibility.Collapsed}"/>
                    </ObjectAnimationUsingKeyFrames>
                    <DoubleAnimation Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Opacity)" To="0"/>
                </Storyboard>
            </VisualState>
            <VisualState x:Name="ThankYou">
                <Storyboard Duration="0:0:0.3">
                    <ObjectAnimationUsingKeyFrames Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Visibility)">
                        <DiscreteObjectKeyFrame KeyTime="0:0:0" Value="{x:Static Visibility.Visible}"/>
                    </ObjectAnimationUsingKeyFrames>
                    <DoubleAnimation Duration="0:0:0.3" Storyboard.TargetName="ThankYouOverlay" Storyboard.TargetProperty="(UIElement.Opacity)" To="1"/>
                </Storyboard>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
