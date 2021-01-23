        <ListView.Resources>
            <ControlTemplate x:Key="SelectedTemplate" TargetType="ListViewItem">
                <Border SnapsToDevicePixels="true" 
                        BorderBrush="{TemplateBinding BorderBrush}" 
                        BorderThickness="{TemplateBinding BorderThickness}" 
                        Background="{TemplateBinding Background}"
                        CornerRadius="5" x:Name="border">
                    <ContentControl 
                        SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                        Margin="2,2,2,2" 
                        VerticalAlignment="Stretch"
                        Content="{TemplateBinding Content}" />
                </Border>
            </ControlTemplate>
            <Style TargetType="ListViewItem">
                <Style.Triggers>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsSelected" Value="true" />
                            <Condition Property="Selector.IsSelectionActive" Value="true" />
                        </MultiTrigger.Conditions>
                        <Setter Property="Background" Value="Pink" />
                        <Setter Property="Template" Value="{StaticResource SelectedTemplate}" />
                    </MultiTrigger>
                </Style.Triggers>
            </Style>
        </ListView.Resources>
       <ListView.View>
    <GridView>
      <GridViewColumn x:Name="LabelColumn" Header="Label" Width="80" DisplayMemberBinding="{Binding Label}" />
      <GridViewColumn x:Name="ValueColumn" Header="Value" Width="80" DisplayMemberBinding="{Binding Value}" />
    </GridView>
