    <Grid>
        <StackPanel>
            <TextBox Text="{Binding TheText}" />
            <Button Command="{Binding ShowOptionsCommand}" Content="..."/>
        </StackPanel>
        <Popup IsOpen="{Binding IsShowingOptions}">
            <StackPanel>
                <ListBox ItemsSource="{Binding Options}" 
                        SelectedItem="{Binding SelectedOption,Mode=TwoWay}"/>
                <Button Command="{Binding SaveOption}">Save</Button>
            </StackPanel>
        </Popup>
    </Grid>
  
    //ShowOptionsCommand handler
    void ShowOptions() 
    {
        IsShowingOptions = true;
    }
    //SaveOptionCommand handler
    void SaveOption() 
    {
        TheText = SelectedOption;
        IsShowingOptions = false;
    }
