            <ListView ItemsSource="{Binding Persons}" Grid.Row="2" Name="GListView" SelectedItem="{Binding SelectedPerson, Mode=TwoWay}">
                <ListView.Resources>
                    <Style TargetType="ListViewItem">
                        <Style.Resources>
                            <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="{x:Static SystemColors.HighlightColor}"/>
                        </Style.Resources>
                    </Style>
                </ListView.Resources>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Name}"/>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
