    <Window.Resources>
        <local:ProductConverter x:Key="ProductConverter" />
        <local:ProductTypeConverter x:Key="ProductTypeConverter" />
    </Window.Resources>
    <TabControl ItemsSource="{Binding MyProducts, 
                Converter={StaticResource ProductConverter}}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock>
                        <TextBlock.Text>
                            <MultiBinding Converter="{StaticResource ProductTypeConverter}">
                                <Binding Path="ProductType"/>
                                <Binding Path="DataContext.MyProductTypes" 
                                         RelativeSource="{RelativeSource AncestorType={x:Type Window}}"/>
                            </MultiBinding>
                        </TextBlock.Text>
                    </TextBlock>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ListBox ItemsSource="{Binding}">
                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Button Width="150" Content="{Binding Description}"/>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
