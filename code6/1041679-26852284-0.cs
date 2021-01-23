                    <Canvas Name="PolyLineCanvas" Width ="100" Height="100">
                        <ItemsControl ItemsSource="{Binding WaypointList,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged,NotifyOnTargetUpdated=True}">
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <Canvas/>
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <ItemsControl ItemsSource="{Binding TracedPathList,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged,NotifyOnTargetUpdated=True}">
                                            <ItemsControl.ItemsPanel>
                                                <ItemsPanelTemplate>
                                                    <Canvas/>
                                                </ItemsPanelTemplate>
                                            </ItemsControl.ItemsPanel>
                                            <ItemsControl.ItemContainerStyle>
                                                <Style TargetType="ContentPresenter">
                                                    <Setter Property="Canvas.Left" Value="{Binding Path=TracedPathLeft, UpdateSourceTrigger=PropertyChanged}"/>
                                                    <Setter Property="Canvas.Top" Value="{Binding Path=TracedPathTop, UpdateSourceTrigger=PropertyChanged}"/>
                                                </Style>
                                            </ItemsControl.ItemContainerStyle>
                                            <ItemsControl.ItemTemplate>
                                                <DataTemplate>
                                                <Polyline StrokeDashArray="{Binding TracedPathDashStyle}" Stroke="{Binding TracedPathColour}" Points="{Binding TracedPath}" StrokeThickness="0.0244"></Polyline>
                                                </DataTemplate>
                                            </ItemsControl.ItemTemplate>
                                        </ItemsControl>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </Canvas>
