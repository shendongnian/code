    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TextBox Grid.Row="1" TextWrapping="Wrap" Text="{Binding CurrentMessage, UpdateSourceTrigger=PropertyChanged}">
            <TextBox.InputBindings>
                <KeyBinding Command="{Binding SendMessageCommand}" Key="Return" />
                <KeyBinding Command="{Binding SendMessageCommand}" Key="Enter" />
            </TextBox.InputBindings>
        </TextBox>
        <Button Content="Send" Grid.Column="1"  Grid.Row="1" Command="{Binding SendMessageCommand}"/>
    </Grid>
