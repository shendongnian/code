      <Style TargetType="TreeViewItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TreeViewItem">
                        <StackPanel>
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="ExpansionStates">
                                    <VisualState x:Name="Expanded">
                                        <Storyboard>
                                            <ObjectAnimationUsingKeyFrames
                                        Storyboard.TargetProperty="(UIElement.Visibility)"
                                        Storyboard.TargetName="ItemsHost">
                                                <DiscreteObjectKeyFrame KeyTime="0"
                                            Value="{x:Static Visibility.Visible}" />
                                            </ObjectAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Collapsed" />
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <ContentPresenter ContentSource="Header" />
                            <ItemsPresenter Name="ItemsHost" Visibility="Collapsed" />
                        </StackPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
