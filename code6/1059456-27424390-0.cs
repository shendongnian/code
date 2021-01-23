    <DataTemplate x:Key="MyTemplate">
                <ListBox Background="Transparent"
                 DataContext="{Binding Source={StaticResource Locator}}"          
                 SelectedItem="{Binding MyViewModel.SelSegment, Mode=TwoWay}">
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="DataContextChanged">
                            <command:EventToCommand Command="{Binding Mode=OneWay,Path=MyViewModel.MyListBox_DataContextChangedCommand}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                </ListBox>
            </DataTemplate>
