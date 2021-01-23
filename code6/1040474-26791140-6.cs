    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="30" />
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0">
            <TextBox Text="{Binding User.FirstName, 
                                    Mode=TwoWay, 
                                    UpdateSourceTrigger=PropertyChanged}" />
            <TextBox Text="{Binding User.LastName, 
                                    Mode=TwoWay, 
                                    UpdateSourceTrigger=PropertyChanged}" />
        </StackPanel>
        
        <Button Grid.Row="1" Content="Save" Command="{Binding SaveCommand}" />
    </Grid>
