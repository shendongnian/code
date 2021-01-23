    <!--ContentPanel - place additional content here-->
            <Grid x:Name="ContentPanel" Grid.Row="1" Margin="12,0,12,0">
                <Grid.RowDefinitions>
                    <RowDefinition Height="*" />
                    <RowDefinition Height="Auto" />
                </Grid.RowDefinitions>
                <ListBox Grid.Row="0" x:Name="listCountries">
                    <ListBox.ItemContainerStyle>
                        <Style TargetType="ListBoxItem">
                            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                        </Style>
                    </ListBox.ItemContainerStyle>
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <toolkit:ExpanderView Header="{Binding}" IsExpanded="{Binding IsExpanded1, Mode=TwoWay}" HeaderTemplate="{StaticResource FirstLevelHeaderTemplate}">
                                <!--ItemsSource="{Binding states}" ItemTemplate="{StaticResource FirstLevelItemTemplate}"-->
                                <toolkit:ExpanderView.Items>
                                    <Grid Height="Auto">
                                        <ListBox  x:Name="listStates" ItemsSource="{Binding states}">
                                            <ListBox.ItemContainerStyle>
                                                <Style TargetType="ListBoxItem">
                                                    <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                                                    <Setter Property="VerticalContentAlignment" Value="Stretch"/>
                                                </Style>
                                            </ListBox.ItemContainerStyle>
                                            <ListBox.ItemsPanel>
                                                <ItemsPanelTemplate>
                                                    <StackPanel/>
                                                </ItemsPanelTemplate>
                                            </ListBox.ItemsPanel>
                                            <ListBox.ItemTemplate>
                                                <DataTemplate>
                                                    <toolkit:ExpanderView Header="{Binding}" 		 						    
    									         IsExpanded="{Binding IsExpanded2, Mode=TwoWay}"
    								             HeaderTemplate="{StaticResource SecondLevelHeaderTemplate}">
                                                        <!-- ItemsSource="{Binding cities}" ItemTemplate="{StaticResource SecondLevelItemTemplate}"-->
                                                        <toolkit:ExpanderView.Items>
                                                            <Grid Height="Auto">
                                                                <ListBox  x:Name="listCities" ItemsSource="{Binding cities}">
                                                                    <ListBox.ItemContainerStyle>
                                                                        <Style TargetType="ListBoxItem">
                                                                            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                                                                            <Setter Property="VerticalContentAlignment" Value="Stretch"/>
                                                                        </Style>
                                                                    </ListBox.ItemContainerStyle>
                                                                    <ListBox.ItemsPanel>
                                                                        <ItemsPanelTemplate>
                                                                            <StackPanel/>
                                                                        </ItemsPanelTemplate>
                                                                    </ListBox.ItemsPanel>
                                                                    <ListBox.ItemTemplate>
                                                                        <DataTemplate>
                                                                            <!--<TextBlock Text="{Binding City}"></TextBlock>-->
                                                                            <toolkit:ExpanderView Header="{Binding}" 		 						    
    									         IsExpanded="{Binding IsExpanded3, Mode=TwoWay}"
    								             HeaderTemplate="{StaticResource ThirdLevelHeaderTemplate}">
                                                                                <!-- ItemsSource="{Binding cities}" ItemTemplate="{StaticResource SecondLevelItemTemplate}"-->
                                                                                <toolkit:ExpanderView.Items>
                                                                                    <Grid Height="Auto">
                                                                                        <ListBox  x:Name="listAreas" ItemsSource="{Binding areas}">
                                                                                            <ListBox.ItemContainerStyle>
                                                                                                <Style TargetType="ListBoxItem">
                                                                                                    <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                                                                                                    <Setter Property="VerticalContentAlignment" Value="Stretch"/>
                                                                                                </Style>
                                                                                            </ListBox.ItemContainerStyle>
                                                                                            <ListBox.ItemsPanel>
                                                                                                <ItemsPanelTemplate>
                                                                                                    <StackPanel/>
                                                                                                </ItemsPanelTemplate>
                                                                                            </ListBox.ItemsPanel>
                                                                                            <ListBox.ItemTemplate>
                                                                                                <DataTemplate>
                                                                                                    <TextBlock Text="{Binding Area}"></TextBlock>
                                                                                                </DataTemplate>
                                                                                            </ListBox.ItemTemplate>
                                                                                        </ListBox>
                                                                                    </Grid>
                                                                                </toolkit:ExpanderView.Items>
                                                                            </toolkit:ExpanderView>
                                                                        </DataTemplate>
                                                                    </ListBox.ItemTemplate>
                                                                </ListBox>
                                                            </Grid>
                                                        </toolkit:ExpanderView.Items>
                                                    </toolkit:ExpanderView>
                                                </DataTemplate>
                                            </ListBox.ItemTemplate>
                                        </ListBox>
                                    </Grid>
                                </toolkit:ExpanderView.Items>
                            </toolkit:ExpanderView>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                </ListBox>
            </Grid>
