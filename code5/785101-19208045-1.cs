    <DataTrigger Binding="{Binding ElementName=MyPanel, Path=(local:MyDependencyClass.IsSliding), Mode=OneWay}" Value="True">
        <DataTrigger.EnterActions>
            <BeginStoryboard>
                <Storyboard>
                    <!-- Here you can show the panel, or use additional animation -->
                    <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetName="MyPanel" Storyboard.TargetProperty="VerticalAlignment">
                        <DiscreteObjectKeyFrame KeyTime="0:0:0">
                            <DiscreteObjectKeyFrame.Value>
                                <VerticalAlignment>Bottom</VerticalAlignment>
                            </DiscreteObjectKeyFrame.Value>
                        </DiscreteObjectKeyFrame>
                    </ObjectAnimationUsingKeyFrames>
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.EnterActions>
    </DataTrigger>
