    <ListView x:Name="MyListGridView">
        <ListView.Resources>
            <My:GetInnerDictionaryValueConverter x:Key="ConverterColum_A1" DictionaryKey="A1" />
            <My:GetInnerDictionaryValueConverter x:Key="ConverterColum_A2" DictionaryKey="A2" />
            <My:GetInnerDictionaryValueConverter x:Key="ConverterColum_A3" DictionaryKey="A3" />
        </ListView.Resources>
        <ListView.View>
            <GridView AllowsColumnReorder="true">
                <GridViewColumn Header="FileName" DisplayMemberBinding="{Binding Key}" />
                <GridViewColumn Header="A1" DisplayMemberBinding="{Binding Converter={StaticResource ConverterColum_A1}}" />
                <GridViewColumn Header="A2" DisplayMemberBinding="{Binding Converter={StaticResource ConverterColum_A2}}" />
                <GridViewColumn Header="A3" DisplayMemberBinding="{Binding Converter={StaticResource ConverterColum_A3}}" />
            </GridView>
        </ListView.View>
    </ListView>
