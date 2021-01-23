        <DataTemplate x:Key="stringEditor">
           <Grid>
               <TextBox Text="{Binding Value, UpdateSourceTrigger=PropertyChanged}"  IsEnabled="{Binding IsReadOnly}"></TextBox>
           </Grid>
        </DataTemplate>
    
    <ContentControl ContentTemplate="{StaticResource stringEditor}"/>
