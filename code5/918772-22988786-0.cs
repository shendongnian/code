    <ListView ItemsSource="{Binding Items}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="False">
                        <Setter Property="Height" Value="20"/>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Dependencies">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Path=Dependencies}" 
                                        Height="{Binding Path=Dependencies.Count, Converter={StaticResource ItemCountToTextBoxHeightConverter}, ConverterParameter=20}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
