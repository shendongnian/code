    <ListView HorizontalAlignment="Left" Width="150" ItemsPanel="{DynamicResource menuLayout}">
        <ListView.Resources>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="ContentTemplate" Value="{StaticResource menuItems}" />
            </Style>
        </ListView.Resources>
        <ListViewItem>
            <ListViewItem.Content>
                <My:ItemData ImageSource="x:\\path\\to\\Img_1.png" Text="Alpha" />
            </ListViewItem.Content>
        </ListViewItem>
        <ListViewItem>
            <ListViewItem.Content>
                <My:ItemData ImageSource="x:\\path\\to\\Img_2.png" Text="Beta" />
            </ListViewItem.Content>
        </ListViewItem>
    </ListView>
