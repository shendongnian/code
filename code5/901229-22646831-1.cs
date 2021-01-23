    <Grid>
        <!--  Hidden textblock, only used for measurement purpose  -->
        <!--  The border is here to set the total height of the display so that we can have a small space between the two halves  -->
        <Border Margin="0,1" Visibility="Hidden">
            <TextBlock Name="SizeRef"
                       Margin="10,0"
                       FontFamily="Courier New"
                       Text="{Binding ElementName=Root,
                                      Path=Letter}" />
        </Border>
        <ContentControl Name="Letter1Top"
                        Background="Gray"
                        Content="{Binding ElementName=Root,
                                          Path=Letter1}"
                        Style="{StaticResource UpperHalf}">
            <ContentControl.RenderTransform>
                <ScaleTransform />
            </ContentControl.RenderTransform>
        </ContentControl>
        <ContentControl Name="Letter2Top"
                        Background="Gray"
                        Content="{Binding ElementName=Root,
                                          Path=Letter2}"
                        Style="{StaticResource UpperHalf}">
            <ContentControl.RenderTransform>
                <ScaleTransform />
            </ContentControl.RenderTransform>
        </ContentControl>
        <ContentControl Name="Letter1Bottom"
                        Background="Gray"
                        Content="{Binding ElementName=Root,
                                          Path=Letter1}"
                        Style="{StaticResource LowerHalf}">
            <ContentControl.RenderTransform>
                <ScaleTransform />
            </ContentControl.RenderTransform>
        </ContentControl>
        <ContentControl Name="Letter2Bottom"
                        Background="Gray"
                        Content="{Binding ElementName=Root,
                                          Path=Letter2}"
                        Style="{StaticResource LowerHalf}">
            <ContentControl.RenderTransform>
                <ScaleTransform />
            </ContentControl.RenderTransform>
        </ContentControl>
    </Grid>
