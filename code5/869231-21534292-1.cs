    <ContentControl Grid.Column="0" Content="{Binding}">
        <ContentControl.Resources>
            <DataTemplate DataType="{x:Type viewModels:foo}">
                <Image Source="foo.png" />
            </DataTemplate>
            <DataTemplate DataType="{x:Type viewModels:bar}">
                <Image Source="bar.png" />
            </DataTemplate>
        </ContentControl.Resources>
    </ContentControl>
