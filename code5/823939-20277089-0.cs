    <GridViewColumn Header="Edit" >
						<GridViewColumn.CellTemplate>
							<DataTemplate >
								<UserControl>
									<Hyperlink Click="InputBox_Click">Edit
										<Hyperlink.Style>
											<Style TargetType="{x:Type Hyperlink}">
												<Setter Property="Hyperlink.IsEnabled" Value="False"/>
												<Style.Triggers>
													<DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=IsSelected}" Value="True">
														<Setter Property="Hyperlink.IsEnabled" Value="True"/>
													</DataTrigger>
											</Style.Triggers>
											</Style>
										</Hyperlink.Style>
                                    </Hyperlink>
								</UserControl>
							</DataTemplate>
						</GridViewColumn.CellTemplate>
					</GridViewColumn>
