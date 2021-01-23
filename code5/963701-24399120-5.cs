    <StackPanel>
        <Button Command="{Binding AddItem}"
                Content="Add Item"/>
        <ListView ItemsSource="{Binding List}"
                  Grid.IsSharedSizeScope="True">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition SharedSizeGroup="name" />
                            <!--other columns-->
                            <ColumnDefinition  />
                        </Grid.ColumnDefinitions>
                        <TextBox Text="{Binding Name}"
                                 FocusManager.FocusedElement="{Binding RelativeSource={RelativeSource Self}}" />
                        <TextBox Text="other column" Grid.Column="1"/>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </StackPanel>
