    <Grid Grid.IsSharedSizeScope="True"><!-- Look HERE -->
        <Grid.RowDefinitions>
            <RowDefinition Height="1*" />
            <RowDefinition Height="7*" />
        </Grid.RowDefinitions>
        <!--  Title  -->
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition SharedSizeGroup="FirstNameColumn" /><!-- Look HERE -->
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <Border Style="{StaticResource borderBase}">
                <TextBlock Text="FirstName" />
            </Border>
            <Border Grid.Column="1" Style="{StaticResource borderBase}">
                <TextBlock Text="SecondName" />
            </Border>
        </Grid>
        <!-- Data -->
        <ListBox Grid.Row="1">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="FirstNameColumn" />
                            <ColumnDefinition /><!--  Look Above HERE  -->
                        </Grid.ColumnDefinitions>
                        <Border Style="{StaticResource borderBase}">
                            <TextBlock Style="{StaticResource textBlockBase}" Text="{Binding FirstName}" />
                        </Border>
                        <Border Grid.Column="1" Style="{StaticResource borderRigth}">
                            <TextBlock Style="{StaticResource textBlockBase}" Text="{Binding SecondName}" />
                        </Border>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
