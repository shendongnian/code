    <Button Content="Click">
       <Button.Triggers>
           <EventTrigger RoutedEvent="Button.Click">
               <BeginStoryboard>
                   <Storyboard>
                       <BooleanAnimationUsingKeyFrames Storyboard.TargetName="theTab" Storyboard.TargetProperty="IsSelected">
                           <DiscreteBooleanKeyFrame KeyTime="0:0:0" Value="True"/>
                       </BooleanAnimationUsingKeyFrames>
                   </Storyboard>
               </BeginStoryboard>
           </EventTrigger>
       </Button.Triggers>
    </Button>
