    <Style TargetType="{x:Type view:SearchInputView}">
       <Setter Property="RenderTransform">
          <Setter.Value>
             <TranslateTransform X="0" Y="0"/>
          </Setter.Value>                     
       </Setter>
       <Style.Triggers>
          <Trigger Property="IsMouseOver" Value="True">
             <Trigger.EnterActions>
                <BeginStoryboard>
                   <Storyboard>
                      <DoubleAnimation Storyboard.TargetProperty="Opacity" From="{StaticResource Transparent}" To="{StaticResource Visible}" Duration="{StaticResource SearchAnimationDuration}"/>
                      <DoubleAnimation Storyboard.TargetProperty="RenderTransform.X" To="0" Duration="0:0:0.4"/>
                   </Storyboard>
                </BeginStoryboard>
             </Trigger.EnterActions>
             <Trigger.ExitActions>
                <BeginStoryboard>
                   <Storyboard>
                      <DoubleAnimation Storyboard.TargetProperty="Opacity" From="{StaticResource Visible}" To="{StaticResource Transparent}" Duration="{StaticResource SearchAnimationDuration}"/>
                      <DoubleAnimation Storyboard.TargetProperty="RenderTransform.X" To="50" Duration="0:0:0.4"/>
                   </Storyboard>
                </BeginStoryboard>
             </Trigger.ExitActions>
          </Trigger>
       </Style.Triggers>
    </Style>
