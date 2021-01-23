    <UserControl.Resources>
    	<gridView:RadContextMenuXamlHolder x:Key="ContextMenuHolder">
    		<telerik:RadContextMenu DataContext="{Binding Path=UIElement.Column.DataControl.DataContext, RelativeSource={RelativeSource Self}}" InheritDataContext="False"
    								StaysOpen="True" x:Name="CellCellContextMenu" Placement="Bottom" Loaded="ContextMenu_OnLoaded">
    			<telerik:RadMenuItem x:Name="ColumnsMenuEntry" Header="Choose Columns:" ItemsSource="{Binding Path=Menu.UIElement.Column.DataControl.Columns, RelativeSource={RelativeSource Self}}" StaysOpenOnClick="True">
    				<telerik:RadMenuItem.ItemContainerStyle>
    					<Style TargetType="telerik:RadMenuItem">
    						<Setter Property="Header" Value="{Binding Header}" />
    						<Setter Property="IsChecked" Value="{Binding IsVisible, Mode=TwoWay}" />
    						<Setter Property="IsCheckable" Value="True" />
    					</Style>
    				</telerik:RadMenuItem.ItemContainerStyle>
    			</telerik:RadMenuItem>
    			<telerik:RadMenuItem Header="Show all columns" Click="RadMenuItem_ShowAllColumns_OnClick"/>
    			<telerik:RadMenuItem Header="Hide all columns" Click="RadMenuItem_HideAllColumns_OnClick"/>
    		</telerik:RadContextMenu>
    	</gridView:RadContextMenuXamlHolder>
    
    	<Style TargetType="telerik:GridViewHeaderCell">
    		<Setter Property="telerik:RadContextMenu.ContextMenu" Value="{Binding Path=CellContextMenu, Source={StaticResource ContextMenuHolder}}"/>
    	</Style>
    	
    	<ResourceDictionary>
    		<ResourceDictionary.MergedDictionaries>
    			<ResourceDictionary Source="pack://application:,,,/Common;component/SharedResources.xaml"/>
    		</ResourceDictionary.MergedDictionaries>
    	</ResourceDictionary>
    </UserControl.Resources>
