    <VisualStateManager.VisualStateGroups>
       <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background).(SolidColorBrush.Color)"
                                            Storyboard.TargetName="Border">
                                                    <EasingColorKeyFrame KeyTime="0" Value="{StaticResource ControlMouseOverColor}" />
                                                </ColorAnimationUsingKeyFrames>
                                                <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextBlock.Foreground).(SolidColorBrush.Color)"
                                            Storyboard.TargetName="Border">
                                                    <EasingColorKeyFrame KeyTime="0" Value="{StaticResource ControlNormalColor}" />
                                                </ColorAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
     </VisualStateManager.VisualStateGroups>
