    <ListView ItemsSource="{Binding}" Grid.Column="0" Grid.Row="1"
          SelectionChanged="ListTeamSelected" SelectionMode="Single">
        <ListView.ItemTemplate>
            <DataTemplate>
                <WrapPanel>
                    <TextBlock Text="{Binding name}" Margin="5"/>
                    <Rectangle Width="25" Margin="5">
                        <Rectangle.Fill>
                            <SolidColorBrush Color="{Binding color}"/>
                        </Rectangle.Fill>
                    </Rectangle>
                    <Rectangle Width="25" Margin="5">
                        <Rectangle.Fill>
                            <SolidColorBrush Color="{Binding secondaryColor}"/>
                        </Rectangle.Fill>
                    </Rectangle>
                </WrapPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
