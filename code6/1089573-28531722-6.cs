        <StackPanel>
            <Grid DockPanel.Dock="Top">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <Menu Grid.Column="0">
                    <MenuItem Header="Static 1"/>
                    <MenuItem Header="Static 2"/>
                </Menu>
                <Menu Grid.Column="1">
                    <Menu.ItemContainerStyle>
                        <Style TargetType="MenuItem">
                            <Setter Property="Header" Value="{Binding HeadText}"/>
                        </Style>
                    </Menu.ItemContainerStyle>
                    <Menu.ItemsSource>
                        <CompositeCollection>
                            <CollectionContainer Collection="{Binding Source={StaticResource source}}"/>
                        </CompositeCollection>
                    </Menu.ItemsSource>
                </Menu>
                <Menu Grid.Column="2">
                    <MenuItem Header="Static 3"/>
                </Menu>
            </Grid>
        </StackPanel>
