    <Window.Resources>
        <ControlTemplate x:Key="inputItemsControlTemplate" TargetType="{x:Type DataGrid}">
            <Grid>
             ....        
            </Grid>
        </ControlTemplate>
    </Window.Resources>
    
        <Grid>
            <DataGrid Name="InputDocItemsDataGrid" />
        </Grid>
    </Window>
Code-behind
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        InputDocItemsDataGrid.Template = (ControlTemplate)this.FindResource("inputItemsControlTemplate");
    }
    private void Window_ContentRendered(object sender, EventArgs e)
    {            
        TextBox txtUCode = (TextBox)InputDocItemsDataGrid.Template.FindName("txtUCode", InputDocItemsDataGrid);
        txtUCode.Focus();
    }
