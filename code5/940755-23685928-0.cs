    <Button.Style>
        <Style TargetType="Button">
            <Setter Property="Foreground" Value="#c10000"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border x:Name="RootElement" CornerRadius="8">
                            <ContentPresenter/>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(Button.Foreground)">
                                                <ObjectAnimationUsingKeyFrames.KeyFrames>
                                                    <DiscreteObjectKeyFrame KeyTime="0:0:0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <SolidColorBrush Color="#FF8D00"/>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames.KeyFrames>
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Button.Style>
