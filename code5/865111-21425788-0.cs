         <ListView>
            <ListView.Style>
                <Style TargetType="ListView">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListView">
                                <ScrollViewer>
                                    <ScrollViewer.Style>
                                        <Style TargetType="ScrollViewer">
                                            <Setter Property="OverridesDefaultStyle" Value="True"/>
                                            <Setter Property="Template">
                                                <Setter.Value>
                                                    <ControlTemplate TargetType="ScrollViewer">
                                                        <!--Grid used for displaying listview item(ScrollContentPresenter Grid.ColumnSpan="2") and vertical scrollviwer(Grid Column="1")-->
                                                        <Grid>
                                                            <Grid.ColumnDefinitions>
                                                                <ColumnDefinition Width="Auto"/>
                                                                <ColumnDefinition/>
                                                            </Grid.ColumnDefinitions>
                                                            <Grid.RowDefinitions>
                                                                <RowDefinition/>
                                                                <RowDefinition Height="Auto"/>
                                                            </Grid.RowDefinitions>
                                                            <!--Listview item will display in ScrollContentPresenter-->
                                                            <ScrollContentPresenter Grid.ColumnSpan="2"/>
                                                            <!--Vertical Scrollviwer style-->
                                                            <ScrollBar Name="PART_VerticalScrollBar" Grid.Column="1" HorizontalAlignment="Right"  Grid.RowSpan="2" Value="{TemplateBinding VerticalOffset}" Maximum="{TemplateBinding ScrollableHeight}" ViewportSize="{TemplateBinding ViewportHeight}" Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}">
                                                                <ScrollBar.Style>
                                                                    <Style TargetType="ScrollBar">
                                                                        <Setter Property="Template">
                                                                            <Setter.Value>
                                                                                <ControlTemplate TargetType="ScrollBar">
                                                                                    <!--you can change height and width of below repeat button -->
                                                                                    <Grid Background="Green">
                                                                                        <Grid.RowDefinitions>
                                                                                            <RowDefinition MaxHeight="18"/>
                                                                                            <RowDefinition Height="0.00001*"/>
                                                                                            <RowDefinition MaxHeight="18"/>
                                                                                        </Grid.RowDefinitions>
                                                                                        <Border Grid.RowSpan="3" CornerRadius="2" Background="#F0F0F0" />
                                                                                        <RepeatButton Grid.Row="0" Height="0" Command="ScrollBar.LineUpCommand" Content="M 0 4 L 8 4 L 4 0 Z" />
                                                                                        <Track Name="PART_Track"  Grid.RowSpan="3" IsDirectionReversed="true">
                                                                                            <Track.DecreaseRepeatButton>
                                                                                                <RepeatButton Height="0" Command="ScrollBar.PageUpCommand" />
                                                                                            </Track.DecreaseRepeatButton>
                                                                                            <Track.Thumb>
                                                                                                <Thumb Background="LightGray" Margin="2" />
                                                                                            </Track.Thumb>
                                                                                            <Track.IncreaseRepeatButton>
                                                                                                <RepeatButton Height="0" Command="ScrollBar.PageDownCommand" />
                                                                                            </Track.IncreaseRepeatButton>
                                                                                        </Track>
                                                                                        <RepeatButton Grid.Row="3"  Height="0" Command="ScrollBar.LineDownCommand" Content="M 0 0 L 4 4 L 8 0 Z"/>
                                                                                    </Grid>
                                                                                </ControlTemplate>
                                                                            </Setter.Value>
                                                                        </Setter>
                                                                    </Style>
                                                                </ScrollBar.Style>
                                                            </ScrollBar>
                                                            <!--similarly you can customize for horizontal scrollviwer-->
                                                            <ScrollBar Name="PART_HorizontalScrollBar" Orientation="Horizontal" Grid.Row="1" Grid.Column="1" Value="{TemplateBinding HorizontalOffset}" Maximum="{TemplateBinding ScrollableWidth}" ViewportSize="{TemplateBinding ViewportWidth}" Visibility="{TemplateBinding ComputedHorizontalScrollBarVisibility}"/>
                                                        </Grid>
                                                    </ControlTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </Style>
                                    </ScrollViewer.Style>
                                    <ItemsPresenter></ItemsPresenter>
                                </ScrollViewer>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.Style>
        </ListView>
