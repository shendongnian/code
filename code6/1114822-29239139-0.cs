    <DataTemplate x:Key="RowLoadingTemplate">
            <Image x:Name="Image" Source="/Interstone.Bestelbonnen;component/Images\loading.png" Visibility="Hidden" RenderTransformOrigin="0.5,0.5">
                <Image.RenderTransform>
                    <RotateTransform x:Name="Rotator" Angle="0"/>
                </Image.RenderTransform>
            </Image>
            <DataTemplate.Triggers>
                <DataTrigger Binding="{Binding IsLoading}" Value="True">
                    <DataTrigger.Setters>
                        <Setter TargetName="Image" Property="Visibility" Value="Visible"/>
                    </DataTrigger.Setters>
                    <DataTrigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="Rotator" Storyboard.TargetProperty="Angle" To="360" Duration="0:0:1" 
                                                 />
                            </Storyboard>
                        </BeginStoryboard>    
                    </DataTrigger.EnterActions>
                </DataTrigger>
            </DataTemplate.Triggers>
        </DataTemplate>
