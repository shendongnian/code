            <ItemsControl ItemsSource="{Binding ViewWrappers}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <ContentControl Content="{Binding View}"/>
                            <Label Content="End of this item." />
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
