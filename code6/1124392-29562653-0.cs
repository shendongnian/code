    <Window.Resources>
     <Style x:Key="CloseStyle">
         <Style.Triggers>
                <DataTrigger Binding="{Binding IsSomething}" Value="False" >
                    <DataTrigger.EnterActions>
                        <BeginStoryboard >
                            <Storyboard Duration="0:0:6" FillBehavior="Stop"  >
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="Close" >
                                    <DiscreteBooleanKeyFrame KeyTime="0:0:5" Value="True" />
                                </BooleanAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard> 
                    </DataTrigger.EnterActions>
                </DataTrigger>
                <DataTrigger Binding="{Binding IsSomething}" Value="True" >
                    <DataTrigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard Duration="0:0:4" FillBehavior="Stop"  >
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="Close" >
                                    <DiscreteBooleanKeyFrame KeyTime="0:0:3" Value="True" />
                                </BooleanAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                </DataTrigger>
            </Style.Triggers>
     </Style>
