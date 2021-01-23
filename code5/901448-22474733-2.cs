     <ComboBox.Visibility>
                        <MultiBinding Converter="{StaticResource NameConverter}">
                            <Binding Path="SelectedItem" ElementName="cbox1"/>
                            <Binding  Path="IsChecked">
                                <Binding.RelativeSource >
                                    <RelativeSource Mode="FindAncestor" AncestorType="{x:Type Window}" />
                                </Binding.RelativeSource>
                                
                            </Binding>
                        </MultiBinding>
                    </ComboBox.Visibility>
   
