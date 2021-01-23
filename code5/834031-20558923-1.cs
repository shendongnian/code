    <Button x:Name="btnLight" Margin="148,0,372,63" VerticalAlignment="Bottom" Command="{Binding OnClickedCommand}" Height="69">
			<Button.Style>
				<Style TargetType="{x:Type Button}">
					<Setter Property="Template">
						<Setter.Value>
							<ControlTemplate>
								<Grid>
									<Ellipse>
										<Ellipse.Fill>
											<ImageBrush ImageSource="image1.png"/>
										</Ellipse.Fill>
									</Ellipse>
								</Grid>
							</ControlTemplate>
						</Setter.Value>
					</Setter>
					<Style.Triggers>
						<DataTrigger Binding="{Binding ImageChanged}" Value="True">
							<Setter Property="Template">
								<Setter.Value>
									<ControlTemplate>
										<Grid>
											<Ellipse>
												<Ellipse.Fill>
													<ImageBrush ImageSource="image2.png"/>
												</Ellipse.Fill>
											</Ellipse>
										</Grid>
									</ControlTemplate>
								</Setter.Value>
							</Setter>
						</DataTrigger>
					</Style.Triggers>
				</Style>
			</Button.Style>
		</Button>
