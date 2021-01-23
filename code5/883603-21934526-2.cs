    <ListBox ItemsSource="{Binding Items}">
       <ListBox.ItemsPanel>
          <ItemsPanelTemplate>
             <StackPanel Orientation="Horizontal"/>
          </ItemsPanelTemplate>
       </ListBox.ItemsPanel>
       <ListBox.ItemContainerStyle>
          <Style TargetType="ListBoxItem">
             <Setter Property="Template">
                <Setter.Value>
                   <ControlTemplate TargetType="ListBoxItem">
                      <Grid>
                         <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="SelectionStates">
                               <VisualState x:Name="Unselected" />
                               <VisualState x:Name="Selected">
                                  <Storyboard>
                                     <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PART_Border" Storyboard.TargetProperty="Background">
                                        <DiscreteObjectKeyFrame KeyTime="0">
                                           <DiscreteObjectKeyFrame.Value>
                                              <SolidColorBrush Color="Red"/>
                                           </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                     </ObjectAnimationUsingKeyFrames>
                                  </Storyboard>
                               </VisualState>
                            </VisualStateGroup>
                         </VisualStateManager.VisualStateGroups>
                         <Border Background="White" x:Name="PART_Border">
                            <ContentPresenter/>
                         </Border>
                      </Grid>
                   </ControlTemplate>
                </Setter.Value>
             </Setter>
          </Style>
       </ListBox.ItemContainerStyle>
       <ListBox.ItemTemplate>
          <DataTemplate>
             <TextBlock Text="lalala" />
          </DataTemplate>
       </ListBox.ItemTemplate>
    </ListBox>
