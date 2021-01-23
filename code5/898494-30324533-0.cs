    <ItemsControl>
            <ItemsControl.Resources>
                <CollectionViewSource x:Key="ProductItems" Source="{Binding SelectedScanViewModel.Products}">
                    <CollectionViewSource.SortDescriptions>
                        <componentModel:SortDescription PropertyName="ProductName" Direction="Ascending"/>
                    </CollectionViewSource.SortDescriptions>
                </CollectionViewSource>
            </ItemsControl.Resources>
            <ItemsControl.ItemsSource>
                <Binding Source="{StaticResource ProductItems}"/>
            </ItemsControl.ItemsSource>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel HorizontalAlignment="Center">
                        <TextBlock Text="{Binding ProductName}" HorizontalAlignment="Center" />
                        <TextBox Name="txtFocus" Text="{Binding Qty}" MinWidth="80" HorizontalAlignment="Center"
                                         behaviors:SelectTextOnFocus.Active="True">
                            <TextBox.TabIndex>
                                <MultiBinding Converter="{StaticResource GetIndexMultiConverter}" ConverterParameter="0">
                                    <Binding Path="."/>
                                    <Binding RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type ItemsControl}}" Path="ItemsSource"/>
                                </MultiBinding>
                            </TextBox.TabIndex>
                        </TextBox>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <UniformGrid Columns="{Binding SelectedScanViewModel.Products.Count}"/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
