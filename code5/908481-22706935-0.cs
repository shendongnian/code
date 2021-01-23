    <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="phone:LongListSelector">
                            <Grid Background="{TemplateBinding Background}" d:DesignWidth="480" d:DesignHeight="800">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="ScrollStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition GeneratedDuration="00:00:00.5"/>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Scrolling">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="VerticalScrollBar"/>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="NotScrolling"/>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="Seleced">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="ViewportControl">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="Green"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Grid Margin="{TemplateBinding Padding}">
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="*"/>
                                        <ColumnDefinition Width="auto"/>
                                    </Grid.ColumnDefinitions>
                                    <ViewportControl x:Name="ViewportControl" HorizontalContentAlignment="Stretch" VerticalAlignment="Top"/>
                                    <ScrollBar x:Name="VerticalScrollBar" Grid.Column="1" Margin="4,0,4,0" Opacity="0" Orientation="Vertical"/>
                                </Grid>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
