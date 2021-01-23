          <ListBox x:Name="lbname" ItemsSource="{Binding source}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <ToggleButton x:Name="btnitem" Content="{Binding Name}">
                            <ToggleButton.IsChecked>
                                <MultiBinding Converter="{StaticResource MyConverter}">
                                    <Binding />
                                    <Binding Path="DataContext.ObservableCollectionToCompare" RelativeSource="{RelativeSource AncestorType={x:Type Window}}"/>
                                </MultiBinding>
                            </ToggleButton.IsChecked>
                        </ToggleButton>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ListBox>
