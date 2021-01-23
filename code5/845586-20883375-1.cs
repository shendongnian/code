    <Grid Width="100%">
          <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <ColumnDefinition />
          </Grid.ColumnDefinitions>
          <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
            <RowDefinition />
            <RowDefinition />
          </Grid.RowDefinitions>
          <Button Name="btn1" Grid.Column="0" Grid.Row="0" Click="OnClick1">
            Button 1
          </Button>
          <Button Name="btn2" Grid.Column="1" Grid.Row="0" Click="OnClick2">
            Button 2
          </Button>
          <!-- More buttons in here as required... -->
    </Grid>
