    <TabItem  Visibility="{Binding Path=MyGabeLib.CurUser.DisplayTSQL, Converter={StaticResource bvc}}">
            <TabItem.Header>
            <TextBlock Style="{StaticResource HeaderTextBlockStyle}">TSQL</TextBlock>
        </TabItem.Header>
        <ScrollViewer VerticalScrollBarVisibility="Visible">
            <TextBox Text="{Binding Path=MyGabeLib.Search.CurrentTSQL, Mode=OneWay}" IsReadOnly="True"
                        TextWrapping="Wrap" FontFamily="Courier New"/>
        </ScrollViewer>
    </TabItem>
