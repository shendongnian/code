        <ItemsControl ItemsSource="{Binding Items}">
            <ItemsControl.GroupStyle>
                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition Width="auto" />
                                                <ColumnDefinition />
                                            </Grid.ColumnDefinitions>
                                            <Border BorderBrush="Black" BorderThickness=".5" Padding="4">
                                                <TextBlock Text="{Binding Name}" VerticalAlignment="Center" />
                                            </Border>
                                            <ItemsPresenter Grid.Column="1" />
                                        </Grid>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </ItemsControl.GroupStyle>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Border BorderBrush="Black" BorderThickness=".5" Padding="4">
                        <TextBlock Text="{Binding Data}" />
                    </Border>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
