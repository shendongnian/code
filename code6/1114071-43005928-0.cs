    <Application.Resources>
        <ResourceDictionary>
            <x:Array Type="Color" x:Key="SeabornColors">
                <Color>#4c72b0</Color>
                <Color>#55a868</Color>
                <Color>#c44e52</Color>
                <Color>#8172b2</Color>
                <Color>#ccb974</Color>
                <Color>#64b5cd</Color>
            </x:Array>
            <Style TargetType="oxy:Plot">
                <Setter Property="DefaultColors" Value="{StaticResource SeabornColors}"/>
            </Style>
        </ResourceDictionary>
    </Application.Resources>
