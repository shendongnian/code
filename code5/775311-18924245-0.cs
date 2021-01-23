    <Grid>
        <Grid.Resources>
            <local:VisibilityToBoolConverter x:Name="VisibilityToBoolConverter" />
        </Grid.Resources>
        <UserControl x:Name="userControl" />
        <ToggleButton 
            IsChecked="{Binding ElementName=userControl,
                                Path=Visibility,
                                Converter={StaticResource VisibilityToBoolConverter}}" 
        />
    </Grid>
