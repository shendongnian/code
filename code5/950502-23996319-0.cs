                <ComboBox Name="LanguageCombo"
                          IsReadOnly="True"
                          SelectedIndex="{Binding LanguageIndex, Mode=OneWayToSource}">
                    <ComboBoxItem Content="{DynamicResource LanguageEnglish}"/>
                    <ComboBoxItem Content="{DynamicResource LanguageFrench}"/>
                    <ComboBoxItem Content="{DynamicResource LanguageGerman}"/>
                    <ComboBoxItem Content="{DynamicResource LanguageItalian}"/>
                    <ComboBoxItem Content="{DynamicResource LanguageJapanese}"/>
                    <ComboBoxItem Content="{DynamicResource LanguagePortuguese}"/>
                    <ComboBoxItem Content="{DynamicResource LanguageSpanish}"/>
                </ComboBox>
