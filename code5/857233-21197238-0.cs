    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <TextBlock Text="{Binding Header, RelativeSource={RelativeSource AncestorType=
            GroupBox}}"/>
        <Rectangle Grid.Row="1" Height="1" Margin="0,2,0,0" Fill="Black">
            <Rectangle.Style>
                <Style>
                    <Setter Property="Rectangle.Visibility" Value="Visible" />
                    <Style.Triggers>
                        <DataTrigger Binding="{IsChecked, ElementName=YourCheckBox}" 
                            Value="False">
                            <Setter Property="Rectangle.Visibility" Value="Collapsed" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Rectangle.Style>
        </Rectangle>
    </Grid>
