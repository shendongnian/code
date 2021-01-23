    <Window.Resources>
        <Style x:Key="Expandable" TargetType="StackPanel">
            <Setter Property="Visibility" Value="Collapsed" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=StackPanel}, Path=IsMouseOver}" Value="True" >
                    <Setter Property="Visibility" Value="Visible" />
                </DataTrigger>
            </Style.Triggers>
        </Style>
    
        <model:LocationType x:Key="LocationTypeInstance"/>
        <DataTemplate x:Key="WastebinTemplate">
            <ContentControl>
                <ContentControl.Content>
                    <StackPanel Name="form">
                            <TextBlock Background="{StaticResource Blue}" Text="{Binding Barcode}"/>
                        <StackPanel x:Name="Verborgen" Background="{StaticResource Orange}" Style="{StaticResource Expandable}">
                            <Button Name="btnRemove" Content="Remove wastebin" Click="btnRemove_Click">
                            </Button>
                            <Label>Adres</Label>
                            <TextBox Name="txbAdres" Text="{Binding Address}"/>
                            <Label>Location type</Label>
                            <ComboBox ItemsSource="{Binding Source={StaticResource LocationTypeInstance}, Path=LocationTypes}" 
                                        DisplayMemberPath="Description" SelectedItem="{Binding LocationType}" SelectedValuePath="ID" SelectedValue="{Binding LocationType.ID}" />
                            <Label>Capaciteit</Label>
                            <Slider Minimum="0" Maximum="100" TickFrequency="10" Value="{Binding Capacity}"></Slider>
                        </StackPanel>
                    </StackPanel>
                </ContentControl.Content>
            </ContentControl>
        </DataTemplate>
    
    </Window.Resources>
