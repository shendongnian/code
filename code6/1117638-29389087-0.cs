    <Popup x:Name="Popup"
                   Placement="Right"
                   PlacementTarget="{Binding ElementName=adorner}">
        <Grid>
            <Border Background="{DynamicResource UI.ErrorBrush}" Padding="5 4">
                            <TextBlock Text="{Binding Path=AdornedElement.(Validation.Errors)[0].ErrorContent,
                                                      RelativeSource={RelativeSource Mode=FindAncestor,
                                                                                     AncestorType={x:Type Adorner}},
                                                      FallbackValue=null, Mode=OneTime}"/>
            </Border>
        </Grid>
    </Popup>
