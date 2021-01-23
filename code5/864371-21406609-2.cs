    <ItemsControl Name="items">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid Visibility="{Binding ShowEven}" Background="Blue">
                            <Image />
                            <Image />
                        </Grid>
                        <Grid Visibility="{Binding ShowOdd}" Background="Red">
                            <TextBlock />
                            <TextBlock />
                        </Grid>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
