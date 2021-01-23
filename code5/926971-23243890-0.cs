     <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>                
                <!-- 
                Merge in the resource dictionary that is shared between the main window and the overview window.
                -->
                <ResourceDictionary Source="SharedVisualTemplates.xaml" />    
            </ResourceDictionary.MergedDictionaries>
    
         <DataTemplate x:Key="InterfacesDataTemplate" DataType="ca:Interface">
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>    
    
                <TextBlock Grid.Column="1"
                   Text="{Binding Path=Name}" />
            </Grid>
        </DataTemplate>
    
    // Other resources
    </ResourceDictionary>
