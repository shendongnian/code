    <Label Content="{Binding SelectedValue.Content, ElementName=list}"  />
    
    <ListBox x:Name="list" SelectedIndex="1"  >
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem" >
                            <RadioButton GroupName="a" Content="{TemplateBinding Content}" IsChecked="{Binding IsSelected, RelativeSource={RelativeSource TemplatedParent}  }"  />
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBoxItem>Create Graph</ListBoxItem>
        <ListBoxItem>Create Map</ListBoxItem>
    </ListBox>
