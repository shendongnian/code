    <somenamespace:WizardViewModel x:Key="WizardViewModelInstance">
    // ....
    <Grid.DataContext="{StaticResource WizardViewModelInstance}">
    // ....
    <TextBox ... Text="{Binding Text}"/>
    <ComboBox ... SelectedItem="{Binding SelectedItem}"/>
    <Button  ... IsEnabled="{Binding IsEnabled}"/>
