    <Label Content="{Binding SelectedValue.Content, ElementName=list}"  />
    
    <ListBox x:Name="list"  >
        <ListBox.ItemContainerStyle >
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem" >
                            <RadioButton Content="{TemplateBinding Content}" IsChecked="{TemplateBinding IsSelected }"  />
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBoxItem>Create Graph</ListBoxItem>
        <ListBoxItem>Create Map</ListBoxItem>
    </ListBox>
