    <ControlTemplate x:Key="MyTemplate">
        <local:ExtendedDataGrid ItemsSource="{Binding Collection,
                                             RelativeSource={RelativeSource
                                           Mode=FindAncestor, AncestorType=Window}}">
             <local:ExtendedDataGrid.Columns>
                 <DataGridTextColumn Binding="{Binding}"/>
             </local:ExtendedDataGrid.Columns>
             <local:ExtendedDataGrid.Triggers>
                 <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                     <BeginStoryboard>
                         <Storyboard>
                            <ObjectAnimationUsingKeyFrames 
                                 Storyboard.TargetProperty="SelectionMode">
                                <DiscreteObjectKeyFrame KeyTime="00:00:00"
                                  Value="{x:Static DataGridSelectionMode.Single}"/>
                            </ObjectAnimationUsingKeyFrames>
                         </Storyboard>
                     </BeginStoryboard>
                 </EventTrigger>
              </local:ExtendedDataGrid.Triggers>
        </local:ExtendedDataGrid>
    </ControlTemplate>
