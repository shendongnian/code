    <ResourceDictionary>
                    <Style x:Key="RootFrameStyle"
                           TargetType="Frame">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="Frame">
                                    <Grid>
                                        <!-- Foreground Player -->
                                        <MediaElement IsLooping="False" />
                                        <!-- Background Player -->
                                        <MediaElement IsLooping="True" />
                                        <Grid>
                                            <ContentPresenter />
                                        </Grid>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ResourceDictionary>
