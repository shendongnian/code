    <StackPanel>
        <ComboBox Name="ComboBox" ItemsSource="{Binding Items}" />
        <TextBox>
            <TextBox.Style>
                <Style>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem.Text, 
                            ElementName=ComboBox}" Value="Male">
                            <Setter Property="TextBox.Text" Value="m" />
                        </DataTrigger>
                        <DataTrigger Binding="{Binding SelectedItem.Text, 
                            ElementName=ComboBox}" Value="Female">
                            <Setter Property="TextBox.Text" Value="f" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
    </StackPanel>
