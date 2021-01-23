    <Window.Resources>
        <Style TargetType="{x:Type DataGridCell}">
            <Style.Triggers>
                <Trigger Property="IsSelected" Value="True">
                    <Setter Property="Background" Value="Red"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        <DataGrid ItemsSource="{Binding Tests}" 
                  SelectedItem="{Binding GridSelectedItem, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                  SelectedIndex="{Binding SelectedGridIndex, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
            
    </DataGrid>
        <Button Command="{Binding ChangeSelectedItemCommand}" 
                Content="Change Grid Selected item" 
                Grid.Column="1" 
                VerticalAlignment="Top"/>
    </Grid>
