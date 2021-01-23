    <ItemsControl Name="lstPanels" ScrollViewer.VerticalScrollBarVisibility="Auto">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel orientation="vertical">
                            <TextBlock Text="{Binding Id}">
                            <TextBox Text="{Binding Text, Mode=TwoWay}" />
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
