    <telerikPrimitives:RadSlideView ItemsSource="{Binding Articles}" 
                        IsLoopingEnabled="False" <!-- Will NOT go back to the beginning -->
                        ItemRealizationMode="ViewportItem">
        <telerikPrimitives:RadSlideView.ItemTemplate>
            <DataTemplate>
                <Grid Margin="12,0,0,0">
                    <!-- Content ->
                </Grid>
            </DataTemplate>
        </telerikPrimitives:RadSlideView.ItemTemplate>
    </telerikPrimitives:RadSlideView>
 
