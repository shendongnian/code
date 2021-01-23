    <DataGrid.RowDetailsTemplate>
      <DataTemplate>
        <Grid MaxHeight="100">
          <ScrollViewer>
            <Border BorderThickness="0" Background="#FFB8E8A1" Padding="5">
              <DataGrid ItemsSource="{Binding Sources}" IsReadOnly="True" SelectionMode="Single" SelectionUnit="FullRow" AutoGenerateColumns="False">
                <DataGrid.Columns>
                  <DataGridTextColumn Width="400" Header="Alarms" Binding="{Binding FilterSource}"></DataGridTextColumn>
                </DataGrid.Columns>
              </DataGrid>
            </Border>
          </ScrollViewer>
        </Grid>
      </DataTemplate>
    </DataGrid.RowDetailsTemplate>
