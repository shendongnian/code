	<Style TargetType="controls:ValidationErrorBorder">
		<Setter Property="IsTabStop" Value="False"/>
		<Setter Property="Template">
			<Setter.Value>
				<ControlTemplate TargetType="controls:ValidationErrorBorder">
					<Grid x:Name="RootElement" Background="{x:Null}">
						<VisualStateManager.VisualStateGroups>
							<VisualStateGroup x:Name="ValidationStates">
								<VisualState x:Name="Valid"/>
								<VisualState x:Name="InvalidUnfocused">
									<Storyboard>
										<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
											<DiscreteObjectKeyFrame KeyTime="0" Value="Visible"/>
										</ObjectAnimationUsingKeyFrames>
									</Storyboard>
								</VisualState>
								<VisualState x:Name="InvalidFocused">
									<Storyboard>
										<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
											<DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
										</ObjectAnimationUsingKeyFrames>
										<ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" Storyboard.TargetName="validationTooltip">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <system:Boolean>True</system:Boolean>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
									</Storyboard>
								</VisualState>
							</VisualStateGroup>
						</VisualStateManager.VisualStateGroups>
                        <Grid>
                            <ContentPresenter Content="{TemplateBinding Content}" ContentTemplate="{TemplateBinding ContentTemplate}" />
                            <Border x:Name="ValidationErrorElement" BorderBrush="#FFDB000C" BorderThickness="1" CornerRadius="1" Visibility="Collapsed">
                                <ToolTipService.ToolTip>
                                    <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" Template="{StaticResource ValidationToolTipTemplate}">
                                        <ToolTip.Triggers>
                                            <EventTrigger RoutedEvent="Canvas.Loaded">
                                                <BeginStoryboard>
                                                    <Storyboard>
                                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsHitTestVisible" Storyboard.TargetName="validationTooltip">
                                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                                <DiscreteObjectKeyFrame.Value>
                                                                    <system:Boolean>True</system:Boolean>
                                                                </DiscreteObjectKeyFrame.Value>
                                                            </DiscreteObjectKeyFrame>
                                                        </ObjectAnimationUsingKeyFrames>
                                                    </Storyboard>
                                                </BeginStoryboard>
                                            </EventTrigger>
                                        </ToolTip.Triggers>
                                    </ToolTip>
                                </ToolTipService.ToolTip>
                                <Grid Background="Transparent" HorizontalAlignment="Right" Height="12" Margin="1,-4,-4,0" VerticalAlignment="Top" Width="12">
                                    <Path Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" Fill="#FFDC000C" Margin="1,3,0,0"/>
                                    <Path Data="M 0,0 L2,0 L 8,6 L8,8" Fill="#ffffff" Margin="1,3,0,0"/>
                                </Grid>
                            </Border>
                        </Grid>
					</Grid>
				</ControlTemplate>
			</Setter.Value>
		</Setter>
	</Style>
