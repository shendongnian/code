    <Viewbox>
            <Canvas Width="50" Height="50"
                    HorizontalAlignment="Left"
                    VerticalAlignment="Top">
                <Path Data="M50,27.5 C50,24.23333 45,24.23333 45,27.5 C45,30.83333 50,30.83333 50,27.5"
                      Fill="#FFFFFFFF"
                      RenderTransformOrigin="0.5,0.83333">
                    <Path.RenderTransform >
                        <RotateTransform x:Name="_rot1" Angle="0"/>
                    </Path.RenderTransform>
                    <Path.Triggers>
                        <EventTrigger RoutedEvent="Path.Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="_rot1"
                                                                   Storyboard.TargetProperty="Angle"
                                                                   RepeatBehavior="Forever">
                                        <EasingDoubleKeyFrame KeyTime="0:0:0" Value="360"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:2" Value="0">
                                            <EasingDoubleKeyFrame.EasingFunction>
                                                <PowerEase Power="1.3" EasingMode="EaseInOut"/>
                                            </EasingDoubleKeyFrame.EasingFunction>
                                        </EasingDoubleKeyFrame>
                                        <EasingDoubleKeyFrame KeyTime="0:0:3" Value="0"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Path.Triggers>
                </Path>
                <Path Data="M50,27.5 C50,24.23333 45,24.23333 45,27.5 C45,30.83333 50,30.83333 50,27.5"
                      Fill="#DDFFFFFF"
                      RenderTransformOrigin="0.5,0.83333">
                    <Path.RenderTransform>
                        <RotateTransform x:Name="_rot2" Angle="13"/>
                    </Path.RenderTransform>
                    <Path.Triggers>
                        <EventTrigger RoutedEvent="Path.Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="_rot2"
                                                                   Storyboard.TargetProperty="Angle"
                                                                   RepeatBehavior="Forever">
                                        <EasingDoubleKeyFrame KeyTime="0:0:0" Value="13"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:0.2" Value="13"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:2.2" Value="-347">
                                            <EasingDoubleKeyFrame.EasingFunction>
                                                <PowerEase Power="1.3" EasingMode="EaseInOut"/>
                                            </EasingDoubleKeyFrame.EasingFunction>
                                        </EasingDoubleKeyFrame>
                                        <EasingDoubleKeyFrame KeyTime="0:0:3" Value="-347"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Path.Triggers>
                </Path>
                <Path Data="M50,27.5 C50,24.23333 45,24.23333 45,27.5 C45,30.83333 50,30.83333 50,27.5"
                      Fill="#BBFFFFFF"
                      RenderTransformOrigin="0.5,0.83333">
                    <Path.RenderTransform>
                        <RotateTransform x:Name="_rot3" Angle="26"/>
                    </Path.RenderTransform>
                    <Path.Triggers>
                        <EventTrigger RoutedEvent="Path.Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="_rot3"
                                                                   Storyboard.TargetProperty="Angle"
                                                                   RepeatBehavior="Forever">
                                        <EasingDoubleKeyFrame KeyTime="0:0:0" Value="26"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="26"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:2.4" Value="-334">
                                            <EasingDoubleKeyFrame.EasingFunction>
                                                <PowerEase Power="1.3" EasingMode="EaseInOut"/>
                                            </EasingDoubleKeyFrame.EasingFunction>
                                        </EasingDoubleKeyFrame>
                                        <EasingDoubleKeyFrame KeyTime="0:0:3" Value="-334"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Path.Triggers>
                </Path>
                <Path Data="M50,27.5 C50,24.23333 45,24.23333 45,27.5 C45,30.83333 50,30.83333 50,27.5"
                      Fill="#99FFFFFF"
                      RenderTransformOrigin="0.5,0.83333">
                    <Path.RenderTransform>
                        <RotateTransform x:Name="_rot4" Angle="39"/>
                    </Path.RenderTransform>
                    <Path.Triggers>
                        <EventTrigger RoutedEvent="Path.Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="_rot4"
                                                                   Storyboard.TargetProperty="Angle"
                                                                   RepeatBehavior="Forever">
                                        <EasingDoubleKeyFrame KeyTime="0:0:0" Value="39"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:0.6" Value="39"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:2.6" Value="-321">
                                            <EasingDoubleKeyFrame.EasingFunction>
                                                <PowerEase Power="1.3" EasingMode="EaseInOut"/>
                                            </EasingDoubleKeyFrame.EasingFunction>
                                        </EasingDoubleKeyFrame>
                                        <EasingDoubleKeyFrame KeyTime="0:0:3" Value="-321"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Path.Triggers>
                </Path>
                <Path Data="M50,27.5 C50,24.23333 45,24.23333 45,27.5 C45,30.83333 50,30.83333 50,27.5"
                      Fill="#77FFFFFF"
                      RenderTransformOrigin="0.5,0.83333">
                    <Path.RenderTransform>
                        <RotateTransform x:Name="_rot5" Angle="52"/>
                    </Path.RenderTransform>
                    <Path.Triggers>
                        <EventTrigger RoutedEvent="Path.Loaded">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="_rot5"
                                                                   Storyboard.TargetProperty="Angle"
                                                                   RepeatBehavior="Forever">
                                        <EasingDoubleKeyFrame KeyTime="0:0:0" Value="52"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:0.8" Value="52"/>
                                        <EasingDoubleKeyFrame KeyTime="0:0:2.8" Value="-308">
                                            <EasingDoubleKeyFrame.EasingFunction>
                                                <PowerEase Power="1.3" EasingMode="EaseInOut"/>
                                            </EasingDoubleKeyFrame.EasingFunction>
                                            </EasingDoubleKeyFrame>
                                        <EasingDoubleKeyFrame KeyTime="0:0:3" Value="-308"/>
                                    </DoubleAnimationUsingKeyFrames>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Path.Triggers>
                </Path>
            </Canvas>
        </Viewbox>
