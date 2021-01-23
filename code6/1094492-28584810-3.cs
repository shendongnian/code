    <Window.DataContext>
        <ViewModel:MyViewModel/>
    </Window.DataContext>
    <Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="{Binding ObjMyViewModel.FirstColumnWidth}" />
        <ColumnDefinition />
    </Grid.ColumnDefinitions>
    <StackPanel>
        <Label>Width:</Label>
        <TextBox Text="{Binding ObjMyViewModel.FirstColumnWidth}" IsReadOnly="True" Background="LightGray" />
    </StackPanel>
    <StackPanel Grid.Column="1">
        <Label>First Column Width:</Label>
        <TextBox Text="{Binding ObjMyViewModel.FirstColumnWidth}" />
        <Label>View Model Data:</Label>
        <TextBox Text="{Binding MyViewModel.PropertyFromVM}" />
        <Label Content="{Binding MyViewModel.PropertyFromVM}" />
    </StackPanel>
