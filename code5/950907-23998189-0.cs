     <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Image Grid.Column="0"
               VerticalAlignment="Top"
               MaxWidth="100"
               Source="https://www.google.com/images/srpr/logo11w.png"></Image>
        
        <DataGrid Grid.Column="1" 
                  Margin="10 0 0 0"
               VerticalAlignment="Top">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Column1"/>
                <DataGridTextColumn Header="Column2"/>
                <DataGridTextColumn Header="Column3"/>
                <DataGridTextColumn Header="Column4"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
