    <Button Content="Close" x:Name="btnClosePopup">
       <Button.Triggers>
          <EventTrigger RoutedEvent="Button.Click">
             <BeginStoryboard>
                <Storyboard>
                   <BooleanAnimationUsingKeyFrames Storyboard.TargetName=" btnInvoiceQuantity" Storyboard.TargetProperty="IsChecked">
                      <DiscreteBooleanKeyFrame Value="False" KeyTime="0:0:0"/>
                   </BooleanAnimationUsingKeyFrames>
                </Storyboard>
             </BeginStoryboard>
          </EventTrigger>
       </Button.Triggers>
    </Button>
