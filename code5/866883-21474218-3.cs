    <StackPanel>
       <TextBox x:Name="BackUpTextBox"/>
       <Button x:Name="BackUpSave" Content="Save" IsEnabled="False"/>
       <StackPanel.Triggers>
          <EventTrigger RoutedEvent="TextBox.TextChanged">
             <BeginStoryboard>
               <Storyboard>
                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled"
                                                Storyboard.TargetName="BackUpSave">
                    <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="True"/>
                </BooleanAnimationUsingKeyFrames>
               </Storyboard>
            </BeginStoryboard>
         </EventTrigger>
         <EventTrigger RoutedEvent="Button.Click">
           <BeginStoryboard>
             <Storyboard>
              <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled"
                                              Storyboard.TargetName="BackUpSave">
                     <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="False"/>
              </BooleanAnimationUsingKeyFrames>
             </Storyboard>
           </BeginStoryboard>
         </EventTrigger>
      </StackPanel.Triggers>
    </StackPanel>
