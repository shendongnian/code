    <Page.Resources>
        <CollectionViewSource x:Name="cvsData"/>
    </Page.Resources>
    <DataTemplate x:Key="xHubListTemplate">
        <ListView x:Name="xHubListView" ItemsSource="{Binding Source={StaticResource cvsData}}" IsItemClickEnabled="True" ItemClick="xHubListView_ItemClick" >
        </ListView>
    </DataTemplate>
