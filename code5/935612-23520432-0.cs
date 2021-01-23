    <Image>
        <Image.Source>
            <MultiBinding Converter="{StaticResource ImageConverter}">
                <Binding Path="ImagePath"/>
                <Binding Path="IsPublic"/>
            </MultiBinding>
        </Image.Source>
    </Image>
