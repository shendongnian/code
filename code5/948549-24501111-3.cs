    <RibbonComboBox IsEditable="False" DataContext="{Binding Path=DefaultSettings}">
        <RibbonGallery SelectedItem="{Binding Path=profile1_papersize, Mode=TwoWay}">
            <RibbonGalleryCategory>
                <RibbonGalleryItem Content="A4" />
                <RibbonGalleryItem Content="B5" />
                <RibbonGalleryItem Content="Letter" />
                <RibbonGalleryItem Content="Legal" />
            </RibbonGalleryCategory>
        </RibbonGallery>
    </RibbonComboBox>
