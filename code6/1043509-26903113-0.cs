    <Page x:Class="DbEditor.Components.ScalarPage" ...>
        <Page.Resources>
            <Grid x:Key="stringEditor" x:Shared="False">
                <TextBox Text="{Binding Value, UpdateSourceTrigger=PropertyChanged}"  IsEnabled="{Binding IsReadOnly}"></TextBox>
            </Grid>
            <Grid x:Key="intEditor" x:Shared="False">
                <TextBox Text="{Binding Value, UpdateSourceTrigger=PropertyChanged}" PreviewTextInput="IntTextBox_PreviewTextInput" IsEnabled="{Binding IsReadOnly}"></TextBox>
            </Grid>
        ...
        </Page.Resources>    
    </Page>
