                                        <Popup IsOpen="{Binding IsSelected}" Placement="Left" PlacementRectangle="20,20,0,0"   >
                                            <TextBlock Text="Yessss this is my popup" Background="AliceBlue" Foreground="Black" />
                                        </Popup>
                                        <DataGridCellsPresenter Grid.Column="1" ItemsPanel="{TemplateBinding ItemsPanel}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                        <DataGridDetailsPresenter Grid.Column="1" Grid.Row="1" SelectiveScrollingGrid.SelectiveScrollingOrientation="{Binding AreRowDetailsFrozen, ConverterParameter={x:Static SelectiveScrollingOrientation.Vertical}, Converter={x:Static DataGrid.RowDetailsScrollingConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" Visibility="{TemplateBinding DetailsVisibility}"/>
                                        <DataGridRowHeader Grid.RowSpan="2" SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical" Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Row}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
                                    </SelectiveScrollingGrid>
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="IsNewItem" Value="True">
                            <Setter Property="Margin" Value="{Binding NewItemMargin, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
                        </Trigger>
                    </Style.Triggers>
                </Style>
