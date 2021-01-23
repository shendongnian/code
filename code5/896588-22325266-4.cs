    <ItemsControl ItemsSource="{Binding RectItems}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Rectangle Width="{Binding Width}" Height="{Binding Height}" Fill="Black">
                    <Rectangle.RenderTransform>
                        <TranslateTransform X="{Binding X}" Y="{Binding Y}"/>
                    </Rectangle.RenderTransform>
                </Rectangle>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
