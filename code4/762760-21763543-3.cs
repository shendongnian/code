    public class StaticSideEnums
    {
        public static Side Bid { get { return Side.Bid; } }
        public static Side Ask { get { return Side.Ask; } }
    }
    <ResourceDictionary>
        <local:StaticSideEnums x:Key="StaticSideEnums"/>
    </ResourceDictionary>
    <toolkit:ListPicker Name="picker" SelectionChanged="OnSelectionChanged">
        <toolkit:ListPickerItem Content="Bid" Tag="{Binding Bid, Source={StaticResource StaticSideEnums}}" />
        <toolkit:ListPickerItem Content="Ask" Tag="{Binding Ask, Source={StaticResource StaticSideEnums}}" />
    </toolkit:ListPicker>
