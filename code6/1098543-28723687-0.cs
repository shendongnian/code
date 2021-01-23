       <ListView Name="ResearchFilters" ItemsSource="{Binding Filters}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ItemsControl ItemsSource="{Binding Items}" Tag="{Binding Path=Type, Mode=OneWay}" BorderThickness="0">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <StackPanel />
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>                              
                                <CheckBox Content="{Binding Mode=OneWay}" Tag="{Binding RelativeSource={RelativeSource AncestorType=ItemsControl}, Path=Tag, Mode=OneWay}" Checked="CheckBox_Checked" Unchecked="CheckBox_Unchecked" Click="CheckBox_Click"></CheckBox>                               
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
