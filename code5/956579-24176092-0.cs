    <ListBox Width="100"
             Height="90"
             ItemsSource="{Binding ListOfItems}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <ToggleButton Command="{Binding SelectItemCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListBox}}"
                              CommandParameter="{Binding}"
                              Content="{Binding}">
                    <ToggleButton.Template>
                        <ControlTemplate TargetType="ToggleButton">
                            <ContentPresenter />
                        </ControlTemplate>
                    </ToggleButton.Template>
                </ToggleButton>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
