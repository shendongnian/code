      <Page.Resources>
    <Style x:Key="ListViewItemTemplate" TargetType="ListViewItem">
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="ListViewItem">
            <Border x:Name="LayoutRoot">
              <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="SelectionStates">
                  <VisualState x:Name="Unselected">
                    <Storyboard>
                      <!-- Define style -->
                      <ObjectAnimationUsingKeyFrames Storyboard.TargetName="container" Storyboard.TargetProperty="Background">
                        <DiscreteObjectKeyFrame KeyTime="0" Value="Transparent"/>
                      </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                  </VisualState>
                  <VisualState x:Name="Selected">
                    <Storyboard>
                      <!-- Define style -->
                      <ObjectAnimationUsingKeyFrames Storyboard.TargetName="container" Storyboard.TargetProperty="Background">
                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneAccentBrush}"/>
                      </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                  </VisualState>
                </VisualStateGroup>
              </VisualStateManager.VisualStateGroups>
              <Grid Margin="0,5" x:Name="container" Background="Transparent">
                <!-- Definition of your list item. -->
              </Grid>
            </Border>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
