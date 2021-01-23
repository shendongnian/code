    <DataTemplate>
        <TextBox x:Name="xTextbox" Grid.Row="0" IsReadOnly="True">
            <TextBox.Style>
                <Style TargetType="TextBox">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsChecked, 
                                     ElementName=PatoRadioButton}" Value="True">
                            <DataTrigger.Setters>
                                <Setter Property="Text" Value="{Binding Path=Item2, 
                                        Mode=OneWay" />
                            </DataTrigger.Setters>
                        </DataTrigger>
                        <DataTrigger Binding="{Binding IsChecked, 
                                     ElementName=FifoRadioButton}" Value="True">
                            <DataTrigger.Setters>
                                <Setter Property="Text" Value="{Binding Path=Item3, 
                                        Mode=OneWay}" />
                            </DataTrigger.Setters>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
    </DataTemplate>
