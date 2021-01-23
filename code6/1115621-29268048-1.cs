    xmlns:Converters="clr-namespace:MyWpfHelpers.Converters;assembly=MyWpfHelpers"
    <UserControl.Resources>
        <ResourceDictionary>
            <Converters:RemoveNewLineConverter x:Key="NoNewline"/>
        </ResourceDictionary>
    </UserControl.Resources>
    <GridViewColumn
        ListViewBehaviors:LayoutColumn.Width="1*"
        ListViewBehaviors:LayoutColumn.MinWidth="123"
        ListViewBehaviors:LayoutColumn.IsHidden="{Binding ExceptionDataIsHidden}"
        DisplayMemberBinding="{Binding ExceptionData, Mode=OneWay, Converter={StaticResource NoNewline}}"
        Header="Exception Data"/>
