        <StackPanel>
            <Button Command="{Binding ToggleCommand}"/>
            <CheckBox IsChecked="{Binding Model.IsChecked}"/>
            <CheckBox IsEnabled="{Binding Model.IsEnabled}"/>
        </StackPanel>
