    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type ComboBox}">
                <Grid>
                    <ToggleButton Name="ToggleButton" 
                                  Template="{StaticResource ComboBoxToggleButton}" 
                                  IsChecked="{Binding Path=IsDropDownOpen, 
                                                      Mode=TwoWay, 
                                                      RelativeSource={RelativeSource TemplatedParent}}" 
                                  Visibility="{TemplateBinding PropertiesExtension:ButtonExt.Visibility}" // <------ Here
                                  Grid.Column="2" 
                                  Focusable="False"                        
                                  ClickMode="Press" />
