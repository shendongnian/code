    <TabControl Name="DocumentsTab"
            ItemsSource="{Binding Documents}">
        <TabControl.ItemTemplate>
            <DataTemplate DataType="{x:Type localmodels:DocumentViewModel}">
                <Label Style="{StaticResource DefaultFont}"
                       Content="{Binding Name}"/>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate DataType="{x:Type localmodels:DocumentViewModel}">
                <Label Style="{StaticResource DefaultFont}"
                       Content="{Binding Name}"/>
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
 
