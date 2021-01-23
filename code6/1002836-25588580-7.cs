    <Grid x:Name="myGrid">
        <Grid.Resources>
            <ResourceDictionary xmlns:sys="clr-namespace:System;assembly=mscorlib">
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="StringResources.xaml" />
                </ResourceDictionary.MergedDictionaries>
                <!--define new resource or even override existing for this specific element -->
                <sys:String x:Key="ThemeData">Theme1.fg.ff00ff00;Theme2.fg.ff0000ff;</sys:String>
                <sys:String x:Key="NewMargins">Margin.16:9.10,5,10,5;</sys:String>
            </ResourceDictionary>
        </Grid.Resources>
        <TextBlock Text="{StaticResource ThemeData}" />
    </Grid>
