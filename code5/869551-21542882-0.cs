    <Grid x:Name="TheObject" Opacity="0">
          <Grid.RenderTransform>
                <TranslateTransform x:Name="MoveMeBaby" X="50" />
          </Grid.RenderTransform>
          <Grid.Triggers>
                <EventTrigger RoutedEvent="Grid.Loaded">
                      <BeginStoryboard>
                             <Storyboard>
                                  <DoubleAnimationUsingKeyFrames Storyboard.TargetName="MoveMeBaby" Storyboard.TargetProperty="X">
                                       <SplineDoubleKeyFrame KeyTime="0:0:1.25" Value="0" />
                                  </DoubleAnimationUsingKeyFrames>
                                  <DoubleAnimationUsingKeyFrames Storyboard.TargetName="TheObject" Storyboard.TargetProperty="Opacity">
                                       <SplineDoubleKeyFrame KeyTime="0:0:1.55" Value="1" />
                                  </DoubleAnimationUsingKeyFrames>
                             </Storyboard>
                      </BeginStoryboard>
                </EventTrigger>
          </Grid.Triggers>
