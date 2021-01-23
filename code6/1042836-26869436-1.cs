    <TabControl Style ="{StaticResource GtlTabControl}"
        ItemsSource="{Binding Images}"
        SelectedIndex="{Binding CurrentImageIndex}"
        AlternationCount="{Binding Path=Items.Count, RelativeSource={RelativeSource Self}}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding Path=(ItemsControl.AlternationIndex), RelativeSource={RelativeSource  FindAncestor, AncestorType=TabItem}}"/>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
