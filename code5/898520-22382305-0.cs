    <ComboBox.ItemContainerStyle>
                    <Style TargetType="{x:Type ComboBoxItem}">
                        <Setter Property="IsEnabled">
                            <Setter.Value>
                                <MultiBinding Converter="{StaticResource IsViewItemConverter}">
                                    <Binding Path="DataContext.CanDisplayDetails" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type ComboBox}}" />
                                    <Binding RelativeSource="{RelativeSource Self}"/>
                                </MultiBinding>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ComboBox.ItemContainerStyle>
