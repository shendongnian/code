     <ComboBox HorizontalAlignment="Left" SelectedItem="{Binding SelectedComboBoxItem, Mode=TwoWay}" ItemsSource="{Binding ComboBoxItems}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="SelectionChanged">
                    <i:InvokeCommandAction Command="{Binding OnCopmboBoxSelectionChangedCommand}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </ComboBox>
