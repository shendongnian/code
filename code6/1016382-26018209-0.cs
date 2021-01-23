    <Setter Property="Validation.ErrorTemplate">
            <Setter.Value>
                <ControlTemplate>
                    <Grid>
                        <Border/>
                        <AdornedElementPlaceholder x:Name="placeholder" />
                        <Popup>
                            <StackPanel>
                                <Polygon/>
                                <Border>
       
                 <TextBlock Text="{Binding ElementName=placeholder, 
                            Path=AdornedElement.(Validation.Errors).CurrentItem.ErrorContent,
                            Mode=OneWay}" />
                                </Border>
                            </StackPanel>
                        </Popup>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
