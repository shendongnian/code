     <Style TargetType="{x:Type local:Substrate}">
         <Setter Property="Template">
             <Setter.Value>
                 <ControlTemplate TargetType="{x:Type local:Substrate}">
                      <Grid>
                         <Grid.ContextMenu>
                             <ContextMenu Background="#212121">
                                  <MenuItem x:Name="myMenuItem" Header="Aborted"> 
                                    </MenuItem>
                              </ContextMenu>
                           </Grid.ContextMenu>
                       </Grid>
                        <ControlTemplate.Triggers>
                           <Trigger SourceName="myMenuItem" Property="IsPressed" Value="true">
                                <Setter Property="SubstrateState" Value="Aborted"></Setter>
                            </Trigger>
                         </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
