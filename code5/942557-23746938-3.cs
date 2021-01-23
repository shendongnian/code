    <Page.Resources>
        <Storyboard x:Name="DeleteStoryboard">
            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="StatusTextBlock">
                <EasingDoubleKeyFrame KeyTime="0:0:0" Value="1"/>
                <EasingDoubleKeyFrame KeyTime="0:0:3" Value="1"/>
                <EasingDoubleKeyFrame KeyTime="0:0:4" Value="0"/>
            </DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </Page.Resources>
    <TextBlock x:Name="StatusTextBlock" Text="{Binding Status}">
        <interactivity:Interaction.Behaviors>
            <core:DataTriggerBehavior Binding="{Binding Status}" ComparisonCondition="NotEqual" Value="">
                <media:ControlStoryboardAction Storyboard="{StaticResource DeleteStoryboard}"/>
            </core:DataTriggerBehavior>
        </interactivity:Interaction.Behaviors>
    </TextBlock>
