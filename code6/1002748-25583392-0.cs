    <ControlTemplate x:Key="ExpanderToggleButtonTemplate" TargetType="{x:Type ToggleButton}">
            <Border x:Name="ExpanderToggleButtonBorder" Height="30">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="Auto"/>
                    </Grid.ColumnDefinitions>
                    <Image Name="img" HorizontalAlignment="Left"></Image>
                    <ContentPresenter x:Name="HeaderContent" Grid.Column="0" Margin="50,0,0,0"
                                  ContentSource="Content" >
                    </ContentPresenter>
                </Grid>
            </Border>
            <ControlTemplate.Triggers>
                <Trigger Property="IsMouseOver"
                                 Value="true">
                    <Setter Property="Source"
                                    Value="path of whichever image is required"
                                    TargetName="img"/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
        <ControlTemplate x:Key="ExpanderTemplate" TargetType="{x:Type Expander}">
            <DockPanel>
                <ToggleButton DockPanel.Dock="Top"
                              Template="{StaticResource ExpanderToggleButtonTemplate}" Content="{TemplateBinding Header}"
                              IsChecked="{Binding Path=IsExpanded, RelativeSource={RelativeSource TemplatedParent}}" OverridesDefaultStyle="True">
                </ToggleButton>
                <ContentPresenter x:Name="ExpanderContent" Grid.Row="1" Visibility="Collapsed" DockPanel.Dock="Bottom"/>
            </DockPanel>
            <ControlTemplate.Triggers>
                <Trigger Property="IsExpanded" Value="True">
                    <Setter TargetName="ExpanderContent" Property="Visibility" Value="Visible"/>
                </Trigger>
            </ControlTemplate.Triggers>
        </ControlTemplate>
    
