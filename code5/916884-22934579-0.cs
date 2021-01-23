    <Button Height="35" Width="200">
        <Button.Template>
            <ControlTemplate TargetType="Button">
                <Grid>
                    <Grid.Resources>
                        <BitmapImage x:Key="NormalButton" UriSource="Assets/NormalButton.png"></BitmapImage>
                        <BitmapImage x:Key="OnMouseOver" UriSource="Assets/OnMouseOver.png"></BitmapImage>
                        <BitmapImage x:Key="OnPresed" UriSource="Assets/OnPresed.png"></BitmapImage>
                    </Grid.Resources>
                    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualState x:Name="Normal"/>
                            <VisualState x:Name="PointerOver">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="ImageSource" Storyboard.TargetName="Border">
                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource OnMouseOver}"/>
                                    </ObjectAnimationUsingKeyFrames>                     
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Pressed">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="ImageSource" Storyboard.TargetName="Border">
                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource OnPresed}"/>
                                    </ObjectAnimationUsingKeyFrames>                                   
                                </Storyboard>
                            </VisualState>
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
                    <Grid>
                        <Grid.Background>
                            <ImageBrush x:Name="Border" ImageSource="{StaticResource NormalButton}"></ImageBrush>
                        </Grid.Background>                      
                        <ContentPresenter x:Name="ContentPresenter" ContentTemplate="{TemplateBinding ContentTemplate}" ContentTransitions="{TemplateBinding ContentTransitions}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                    </Grid>
                </Grid>
            </ControlTemplate>
        </Button.Template>        
    </Button>
