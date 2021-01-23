        <ComboBox
            IsEditable="True"
            ItemsSource="{Binding Items}"
            SelectedItem="{Binding SelectedItem}"
            Text="{Binding Text, UpdateSourceTrigger=PropertyChanged}">
            <i:Interaction.Triggers>
                <i:EventTrigger
                    EventName="LostFocus">
                    <i:InvokeCommandAction
                        Command="{Binding Command}" />
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </ComboBox>
