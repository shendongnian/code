    <Style TargetType="{x:Type GroupItem}">
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="{x:Type GroupItem}">
                                                <DockPanel>
                                                    <Grid DockPanel.Dock="Bottom" >
                                                        <Grid.ColumnDefinitions>
                                                            <ColumnDefinition Width="{Binding ElementName=first, Path=Width, UpdateSourceTrigger=PropertyChanged}" />
                                                            <ColumnDefinition Width="{Binding ElementName=second, Path=Width, UpdateSourceTrigger=PropertyChanged}" />
                                                        </Grid.ColumnDefinitions>
                                                        <ScrollBar Grid.Column="0" Orientation="Horizontal" Scroll="ScrollBar1_Scroll"
                                                              Width="{Binding ElementName=first, Path=Width, UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}" >
                                                  
                                                        </ScrollBar>
                                                        <ScrollBar Grid.Column="1" Orientation="Horizontal" Scroll="ScrollBar2_Scroll"
                                                                   Width="{Binding ElementName=second, Path=Width, UpdateSourceTrigger=PropertyChanged,Mode=TwoWay}"/>
                                                    </Grid>
                                                    <ItemsPresenter />
                                                </DockPanel>
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </Style>
