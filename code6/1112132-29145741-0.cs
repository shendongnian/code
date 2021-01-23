    <MultiDataTrigger>
       <MultiDataTrigger.Conditions>
          <Condition Binding="{Binding Path=HasPath}" Value="True" />
          <Condition Binding="{Binding Path=IsBig}" Value="False" />
       </MultiDataTrigger.Conditions>
       <MultiDataTrigger.EnterActions>
          <BeginStoryboard x:Name="BeginStoryboardName">
             <Storyboard>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Left)" 
                                               Duration="0:0:3" RepeatBehavior="Forever">
                   <DiscreteDoubleKeyFrame Value="77" KeyTime="0:0:0" />
                   <DiscreteDoubleKeyFrame Value="73" KeyTime="0:0:1" />
                   <DiscreteDoubleKeyFrame Value="138" KeyTime="0:0:2" />
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(Canvas.Top)" 
                                               Duration="0:0:3" RepeatBehavior="Forever">
                   <DiscreteDoubleKeyFrame Value="57" KeyTime="0:0:0" />
                   <DiscreteDoubleKeyFrame Value="97" KeyTime="0:0:1" />
                   <DiscreteDoubleKeyFrame Value="53" KeyTime="0:0:2" />
                </DoubleAnimationUsingKeyFrames>
             </Storyboard>
          </BeginStoryboard>
       </MultiDataTrigger.EnterActions>
       <MultiDataTrigger.ExitActions>
          <RemoveStoryboard BeginStoryboardName="BeginStoryboardName"/>
       </MultiDataTrigger.ExitActions>
    </MultiDataTrigger>
