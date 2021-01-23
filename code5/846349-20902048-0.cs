       <ControlTemplate.Triggers>
                            <Trigger Property="IsPressed" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(Rectangle.RenderTransform).(ScaleTransform.ScaleX)"
                                            To="0.95"  Duration="0:0:0.05" />
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(Rectangle.RenderTransform).(ScaleTransform.ScaleY)" 
                                            To="0.95" Duration="0:0:0.05" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(Rectangle.RenderTransform).(ScaleTransform.ScaleX)"
                                            To="1.08"  Duration="0:0:0.05" />
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(Rectangle.RenderTransform).(ScaleTransform.ScaleY)" 
                                            To="1.08" Duration="0:0:0.05" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.ExitActions>
                            </Trigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsMouseOver" Value="True"/>
                                    <Condition Property="IsPressed" Value="False"/>
                                </MultiTrigger.Conditions>
                                <MultiTrigger.EnterActions>
                                    <BeginStoryboard >
                                        <Storyboard >
                                            <DoubleAnimation 
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(FrameworkElement.RenderTransform).(ScaleTransform.ScaleX)"
                                            To="1.08"  Duration="0:0:0.05" />
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(FrameworkElement.RenderTransform).(ScaleTransform.ScaleY)" 
                                            To="1.08" Duration="0:0:0.05" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.EnterActions>
                                <MultiTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard >
                                            <DoubleAnimation
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(FrameworkElement.RenderTransform).(ScaleTransform.ScaleX)"
                                            To="1.00"  Duration="0:0:0.05" />
                                            <DoubleAnimation 
                                            Storyboard.TargetName="ButtonGrid" 
                                            Storyboard.TargetProperty="(FrameworkElement.RenderTransform).(ScaleTransform.ScaleY)" 
                                            To="1.00" Duration="0:0:0.05" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </MultiTrigger.ExitActions>
                            </MultiTrigger>                        
                        </ControlTemplate.Triggers>
