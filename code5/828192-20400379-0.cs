    <Grid>
        <Grid.Resources>
            <DataTemplate x:Key="DataTemplate" >
                <Grid>
                    <TextBox Text="{Binding}" Visibility="{StaticResource EnumToVisibilityConverter, ConverterParameter=Int}" />
                    <DateTimePicker SelectedDate="{Binding}" Visibility="{StaticResource EnumToVisibilityConverter, ConverterParameter=DateTime}" />
                    <ComboBox SelectedItem="{Binding}" Visibility="{StaticResource EnumToVisibilityConverter, ConverterParameter=Bool}">
                        <ComboBox.Items>
                            <ComboBoxItem>True</ComboBoxItem>
                            <ComboBoxItem>False</ComboBoxItem>
                        </ComboBox.Items>
                    <ComboBox>
                    ... <!--Complete this yourself-->
                </Grid>
            </DataTemplate>
        </Grid.Resources>
        <DataGrid Name="DG1" ItemsSource="{Binding}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Some column" CellTemplate="{StaticResource DataTemplate}" />
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
