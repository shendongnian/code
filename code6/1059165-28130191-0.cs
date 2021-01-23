        <ListBox ItemsSource="{Binding RadioCollection}" SelectedItem="{Binding SelectedRadio}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type ListBoxItem}">
                                <TextBlock Text="{Binding AbstractGroupHeader}" />
                                <RadioButton 
                                    Content="{Binding Header}" ToolTip="{Binding ToolTip}"
                                    IsChecked="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=IsSelected}"/>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Margin" Value="5"/>
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
