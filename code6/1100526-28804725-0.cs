     <ItemsControl Grid.Row="1" ItemsSource="{Binding Collection}" AlternationCount="{Binding Path=Collection.Count}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Vertical" />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <TextBlock  Text="{Binding}" ToolTip="{Binding Path=(ItemsControl.AlternationIndex),   RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContentPresenter}}">
                        </TextBlock>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
