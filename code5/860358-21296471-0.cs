        <ComboBox Grid.Column="0" ItemsSource="{Binding Ids}" SelectedItem="{Binding MyID}" />
        <ListView Name="Listview1" Grid.Column="1" ItemsSource="{Binding ObjectList}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Header1" DisplayMemberBinding="{Binding subObject.property}"/>
                    <GridViewColumn Header="Header2" >
                        <GridViewColumn.DisplayMemberBinding>
                            <MultiBinding Converter="{StaticResource IDictionarySelector}">
                                <Binding Path="PropertyOfAnItemInAList" />
                                <Binding Path="DataContext.MyID" RelativeSource="{RelativeSource AncestorType={x:Type Window}}" />
                            </MultiBinding>
                        </GridViewColumn.DisplayMemberBinding>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
