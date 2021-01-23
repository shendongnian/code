    <ItemsControl VerticalAlignment="Top" Visibility="Collapsed" x:Name="RadioList">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid Margin="12" Tag="{Binding}">
                    <i:Interaction.Triggers>
                                    <i:EventTrigger EventName="Tap">
                                        <i:InvokeCommandAction Command="{Binding YourCommand}" />
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
