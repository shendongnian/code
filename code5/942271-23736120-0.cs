           <ListView AlternationCount="{Binding ItemsSource.Count, RelativeSource={RelativeSource Self}}"  ItemsSource="{Binding ListOfStrings}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <Expander Header="My">
                            <Expander.Style>
                                <Style TargetType="Expander">
                                    <Setter Property="Visibility" Value="Collapsed"></Setter>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding (ItemsControl.AlternationIndex), RelativeSource={RelativeSource FindAncestor, AncestorType=ListViewItem}}" Value="0">
                                            <Setter Property="Visibility" Value="Visible"></Setter>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Expander.Style>
                        </Expander>
                        <TextBlock Text="{Binding}"/>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
