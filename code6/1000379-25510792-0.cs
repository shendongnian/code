    <Style x:Key="GrowOnPressedThingy" TargetType="Button">        
      <Setter Property="HorizontalContentAlignment" Value="Center" />
      <Setter Property="VerticalContentAlignment" Value="Center" />
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="Button">
            <Grid x:Name="Container"
                  RenderTransformOrigin="0.5,0.5">
              <Grid.RenderTransform>
                <TransformGroup>
                  <ScaleTransform />
                  <SkewTransform />
                  <RotateTransform />
                  <TranslateTransform />
                </TransformGroup>
              </Grid.RenderTransform>
              <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                  <VisualStateGroup.Transitions>
                    <!-- Just left for reference -->
                  </VisualStateGroup.Transitions>
                  <VisualState x:Name="Normal" />
                  <VisualState x:Name="MouseOver"/>
                  <VisualState x:Name="Pressed">
                    <Storyboard>
                      <DoubleAnimationUsingKeyFrames Storyboard.TargetName="Container" 
                                                     Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.01" Value="1.05" />
                      </DoubleAnimationUsingKeyFrames>
                      <DoubleAnimationUsingKeyFrames Storyboard.TargetName="Container" 
                                                     Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)">
                        <EasingDoubleKeyFrame KeyTime="0:0:0.01" Value="1.05" />
                      </DoubleAnimationUsingKeyFrames>
                    </Storyboard>
                  </VisualState>
                  <VisualState x:Name="Disabled"/>
                </VisualStateGroup>
                <VisualStateGroup x:Name="FocusStates">
                  <VisualState x:Name="Focused"/>
                  <VisualState x:Name="Unfocused" />
                </VisualStateGroup>
              </VisualStateManager.VisualStateGroups>
                            
              <ContentControl x:Name="contentPresenter"
                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                              VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                              Content="{TemplateBinding Content}"
                              ContentTemplate="{TemplateBinding ContentTemplate}"
    										      IsTabStop="False"/>
    										      
            </Grid>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
