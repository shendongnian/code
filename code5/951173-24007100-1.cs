    <CheckBox>
        <CheckBox.IsChecked>
            <MultiBinding Converter="{StaticResource HasTennantConverter}" Mode="OneWay">
                <Binding />
                <Binding Path="DataContext.CurrentProperty" RelativeSource="{RelativeSource Mode=FindAncestor, AncestorType=Window}"/>
            </MultiBinding>
        </CheckBox.IsChecked>
    </CheckBox>
