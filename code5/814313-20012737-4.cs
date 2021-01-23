    <ListView x:Name="MyListGridView">
        <ListView.View>
            <GridView AllowsColumnReorder="true">
                <My:GridViewColumnFileName Header="FileName" />
                <My:GridViewColumnInnerDictionaryValue Header="A1" InnerDictionaryKey="A1" />
                <My:GridViewColumnInnerDictionaryValue Header="A2" InnerDictionaryKey="A2" />
                <My:GridViewColumnInnerDictionaryValue Header="A3" InnerDictionaryKey="A3" />
            </GridView>
        </ListView.View>
    </ListView>
