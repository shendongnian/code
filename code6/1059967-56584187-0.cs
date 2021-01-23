<Window.Resources>
        <ControlTemplate x:Key="DataGridGroupExpender" TargetType="{x:Type GroupItem}">
            <Expander IsExpanded="True" Background="LightGray" BorderThickness="1,1,1,1">
                <Expander.Header>
                    <DockPanel>
                        <TextBlock FontWeight="Bold" Text="{Binding Path=Name}" Margin="5,0,0,0"/>
                        <TextBlock FontWeight="Bold" Text="{Binding Path=ItemCount, StringFormat=: {0}}"/>
                    </DockPanel>
                </Expander.Header>
                <Expander.Content>
                    <ItemsPresenter />
                </Expander.Content>
            </Expander>
        </ControlTemplate>
        <ControlTemplate x:Key="DataGridGroupNoExpender" TargetType="{x:Type GroupItem}">
            <ItemsPresenter />
        </ControlTemplate>
</Window.Resources>
Use DataTrigger to switch ContainerStyle based on number of items in the group: 1 means no child and therefor no Expander. 
                        <GroupStyle>
                            <GroupStyle.ContainerStyle>
                                <Style TargetType="{x:Type GroupItem}">
                                    <Setter Property="Margin" Value="0,0,0,5"/>
                                    <Setter Property="Template"  Value="{StaticResource DataGridGroupExpender}"/>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding Path=ItemCount}" Value="1">
                                            <Setter Property="Template" Value="{StaticResource DataGridGroupNoExpender}"/>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </GroupStyle.ContainerStyle>
                        </GroupStyle>
