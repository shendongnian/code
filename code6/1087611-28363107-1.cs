    <ListView Name="listView1" ItemsSource="{Binding A}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ContentPresenter Content="{Binding}">
                    <ContentPresenter.InputBindings>
                        <MouseBinding Gesture="LeftClick" Command="{Binding DataContext.ItemSelectCommand, ElementName=listView1}" CommandParameter="{Binding ElementName=listView1,Path=SelectedItem}"/>
                    </ContentPresenter.InputBindings>
                </ContentPresenter>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
