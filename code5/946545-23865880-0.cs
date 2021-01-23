         <Grid>
            <Grid.Resources>
                <Style TargetType="{x:Type TabControl}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type TabControl}">
                                <Grid KeyboardNavigation.TabNavigation="Local">
                                    <Grid.RowDefinitions>
                                        <RowDefinition />
                                        <RowDefinition Height="Auto"/>
                                    </Grid.RowDefinitions>
                                    <ContentPresenter ContentSource="SelectedContent"/>
                                    <TabPanel  Grid.Row="1" IsItemsHost="True" />
                                   
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Grid.Resources>
    
            <TabControl TabStripPlacement="Bottom" >
                <TabItem Header="tab1">fff</TabItem>
                <TabItem Header="tab2"></TabItem>
                <TabItem Header="tab3"></TabItem>
            </TabControl>
    
        </Grid>
