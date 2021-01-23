                  <DataTemplate.Triggers>
                            <DataTrigger Binding="{Binding Removing}" Value="True">
                                <DataTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation Duration="0:0:1" From="1.0" To="0.0"
                                               Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ItemBorder" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </DataTrigger.EnterActions>
    
                            </DataTrigger>
                 </DataTemplate.Triggers>
