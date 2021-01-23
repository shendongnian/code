    <ListBox ItemsSource="{Binding Current.Groups}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Path=CurrentId,
                                                StringFormat={}CurrentID: {0}}"/>
                    <TextBlock Text="{Binding Path=DataContext.Current.CurrentId,
                                                StringFormat={}ParentID: {0}, 
                                                RelativeSource={RelativeSource AncestorType=Grid}}"/>
                    <StackPanel.Style>
                        <Style TargetType="StackPanel">
                            <Setter Property="Background" Value="Red"/>
                            <Style.Triggers>
                                <DataTrigger Value="True">
                                    <DataTrigger.Binding>
                                        <MultiBinding Converter="{StaticResource IntEqualConverter}">
                                            <Binding Path="CurrentId"/>
                                            <Binding Path="DataContext.Current.CurrentId"
                                                     RelativeSource="{RelativeSource AncestorType=Grid}"/>
                                        </MultiBinding>
                                    </DataTrigger.Binding>
                                    <DataTrigger.Setters>
                                        <Setter Property="Background" Value="Green"/>
                                    </DataTrigger.Setters>                   
                                </DataTrigger>                                        
                            </Style.Triggers>
                        </Style>
                    </StackPanel.Style>
                                   
                </StackPanel>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
