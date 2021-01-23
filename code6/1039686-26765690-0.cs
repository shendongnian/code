    <TabControl ...>
        <TabControl.Template>
            <ControlTemplate TargetType="{x:Type TabControl}">
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <ScrollViewer HorizontalScrollBarVisibility="Auto">
                        <TabPanel x:Name="HeaderPanel" IsItemsHost="True"/>
                    </ScrollViewer>
                    <ContentPresenter x:Name="PART_SelectedContentHost" Margin="4" ContentSource="SelectedContent" Grid.Row="1"/>
                </Grid>
            </ControlTemplate>
        </TabControl.Template>
    </TabControl>
