    <ControlTemplate TargetType="{x:Type CheckBox}">
          <ControlTemplate.Resources>
            <Storyboard x:Key="ffIsEnabled" Storyboard.TargetProperty="IsEnabled">
               <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled">
                   <DiscreteBooleanKeyFrame KeyTime="0" Value="False"/>
                   <DiscreteBooleanKeyFrame KeyTime="0:0:3" Value="True"/>
               </BooleanAnimationUsingKeyFrames>
            </Storyboard>
          </ControlTemplate.Resources>
          <ControlTemplate.Triggers>
             <Trigger Property="IsChecked" Value="True">
                <Trigger.EnterActions>
                   <BeginStoryboard Storyboard="{StaticResource ffIsEnabled}"/>                                                
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                   <BeginStoryboard Storyboard="{StaticResource ffIsEnabled}"/>
                </Trigger.ExitActions>
             </Trigger>
          </ControlTemplate.Triggers>
          <!-- ... -->
    </ControlTemplate>
