					<Setter.Value>
						<ControlTemplate TargetType="{x:Type TabItem}">
							<Grid x:Name="templateRoot" SnapsToDevicePixels="true">
								<VisualStateManager.VisualStateGroups>
									<VisualStateGroup x:Name="CommonStates"/>
									<VisualStateGroup x:Name="SelectionStates">
										<VisualStateGroup.Transitions>
											<VisualTransition GeneratedDuration="0:0:0.3"/>
										</VisualStateGroup.Transitions>
										<VisualState x:Name="Unselected">
											<Storyboard>
												<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="templateRoot">
													<EasingDoubleKeyFrame KeyTime="0" Value="0.8"/>
												</DoubleAnimationUsingKeyFrames>
											</Storyboard>
										</VisualState>
										<VisualState x:Name="Selected"/>
									</VisualStateGroup>
								</VisualStateManager.VisualStateGroups>
