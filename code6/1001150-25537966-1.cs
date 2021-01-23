    <ListBox>
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding Who.value}" />
                    <TextBlock Grid.Column="1" Text="{Binding What.value}" />
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="HorizontalAlignment" Value="Stretch" />
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
