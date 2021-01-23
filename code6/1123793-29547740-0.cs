        <Style TargetType="ListViewItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListViewItem">
                        <Grid>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Selected">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00"
                                                                           Storyboard.TargetName="Rect"
                                                                           Storyboard.TargetProperty="Height">
                                                <EasingDoubleKeyFrame KeyTime="00:00:00.5" Value="50">
                                                    <EasingDoubleKeyFrame.EasingFunction>
                                                        <CubicEase />
                                                    </EasingDoubleKeyFrame.EasingFunction>
                                                </EasingDoubleKeyFrame>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Unselected">
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames BeginTime="00:00:00"
                                                                           Storyboard.TargetName="Rect"
                                                                           Storyboard.TargetProperty="Height">
                                                <EasingDoubleKeyFrame KeyTime="00:00:00.5" Value="25">
                                                    <EasingDoubleKeyFrame.EasingFunction>
                                                        <CubicEase />
                                                    </EasingDoubleKeyFrame.EasingFunction>
                                                </EasingDoubleKeyFrame>
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Border x:Name="Rect"
                                    Height="25"
                                    Background="Transparent"
                                    BorderBrush="Red"
                                    BorderThickness="1">
                                <ContentPresenter x:Name="contentPresenter"
                                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                                  Content="{TemplateBinding Content}"
                                                  ContentTemplate="{TemplateBinding ContentTemplate}" />
                            </Border>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
