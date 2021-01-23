     <Window.Resources>
        <DataTemplate  x:Key="listItemTemplate">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition />
                    <ColumnDefinition />
                </Grid.ColumnDefinitions>
                
                <Label Content="{Binding Title}"/>
                <ComboBox Grid.Column="1" ItemsSource="{Binding Collection}" DisplayMemberPath="{Binding DisplayMemeberPath}"/>
                
            </Grid>            
        </DataTemplate>
        
    </Window.Resources>
                
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition />
        </Grid.RowDefinitions>
        
        
        <Button Content="Add List" Click="Button_Click"/>
        
        <ScrollViewer Grid.Row="1">
            <ItemsControl ItemTemplate="{StaticResource listItemTemplate}" ItemsSource="{Binding Items}"/>
        </ScrollViewer>
    </Grid>
