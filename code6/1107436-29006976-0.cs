    <Expander>
        <Expander.Header>
            <ItemsControl ItemsSource="{Binding ElementName=PART_ListBox, Path=SelectedItems}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <TextBlock>
                            <Run Text="{Binding Mode=OneWay}" />
                            <Run Text=";" />
                        </TextBlock>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
            </ItemsControl>
        </Expander.Header>
        <Expander.Content>
            <ListBox x:Name="PART_ListBox" SelectionMode="Multiple">
                <ListBox.ItemsSource>
                    <x:Array Type="system:String">
                        <system:String>ABC</system:String>
                        <system:String>DEF</system:String>
                        <system:String>GHI</system:String>
                        <system:String>JKL</system:String>
                    </x:Array>
                </ListBox.ItemsSource>
            </ListBox>
        </Expander.Content>
    </Expander>
