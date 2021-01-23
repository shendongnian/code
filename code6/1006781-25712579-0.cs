    <TabControl ...>
      <TabControl.ItemTemplate>
        <DataTemplate>
          <StackPanel Orientation="Horizontal">
            <TextBlock Text="{Binding Path=CustomerId}" />
            <Button Command="{Binding Path=RemoveItemCommand, Mode=OneTime,
                              RelativeSource={RelativeSource FindAncestor,
                                              AncestorType={x:Type TabControl}}"
                    CommandParameter="{Binding}" />
          </StackPanel>
        </DataTemplate>
      <TabControl.ItemTemplate>
    </TabControl>
