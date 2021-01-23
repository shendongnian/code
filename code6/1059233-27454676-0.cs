    <ListView ItemsSource="{Binding CountryDetails}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="ControlTemplate">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListViewItem">
                            <Grid>
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualState x:Name="Selected">                                    
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames
                                                     Storyboard.TargetName="countryName"
                                                     Storyboard.TargetProperty="Visibility">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="Visible" />
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Image Source="{Binding RelativeSource={RelativeSource TemplatedParent},Path=Content.flagImages}" CacheMode="BitmapCache" />
                                <TextBlock Visibility="Collapsed" Name="countryName" Text="{Binding RelativeSource={RelativeSource TemplatedParent},Path=Content.countryTitle}"></TextBlock>                        
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
           </Style>
        </ListView.ItemContainerStyle>
    </ListView>
