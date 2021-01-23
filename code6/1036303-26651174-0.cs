    <StackPanel>
       <StackPanel.Triggers>
           <EventTrigger RoutedEvent="Loaded">
              <BeginStoryboard>
                  <Storyboard Storyboard.TargetProperty="Opacity"  
                              RepeatBehavior="Forever">
                     <DoubleAnimationUsingKeyFrames Storyboard.TargetName="i1"
                                                    BeginTime="0:0:0">
                        <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="0"/>
                        <DiscreteDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
                     </DoubleAnimationUsingKeyFrames>
                     <DoubleAnimationUsingKeyFrames Storyboard.TargetName="i2" 
                                                    BeginTime="0:0:1">
                        <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="0"/>
                        <DiscreteDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
                     </DoubleAnimationUsingKeyFrames>
                     <DoubleAnimationUsingKeyFrames Storyboard.TargetName="i3" 
                                                BeginTime="0:0:2" Duration="0:0:3">
                        <DiscreteDoubleKeyFrame KeyTime="0:0:0" Value="0"/>
                        <DiscreteDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
                     </DoubleAnimationUsingKeyFrames>
                  </Storyboard>
              </BeginStoryboard>
           </EventTrigger>
       </StackPanel.Triggers>
       <TextBlock Name="i1">Item 1</TextBlock>
       <TextBlock Name="i2">Item 2</TextBlock>
       <TextBlock Name="i3">Item 3</TextBlock>
    </StackPanel>
