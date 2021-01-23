    <RibbonMenuButton Label="Meeting" ItemsSource="{Binding MeetingsAvailable}" ... >
        <RibbonMenuButton.ItemTemplate>                            
            <DataTemplate>
                <TextBlock Text="{Binding Value}"/>
            </DataTemplate>
        </RibbonMenuButton.ItemTemplate>
        <RibbonMenuButton.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}">
                <Setter Property="Command" Value="{Binding DataContext.NameOfCommand,
                    RelativeSource={RelativeSource AncestorType={x:Type Views:View}}}" />
                <Setter Property="CommandParameter" Value="{Binding Key}" />
            </Style>
        </RibbonMenuButton.ItemContainerStyle>                                         
    </RibbonMenuButton>
