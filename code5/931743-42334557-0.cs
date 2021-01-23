    <Style TargetType="{x:Type TabItem}">
            <Setter Property="Padding" Value="1" />
            <Setter Property="HeaderTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <Border Background="Orange">
                            <ContentPresenter>
                                <ContentPresenter.Content>
                                    <TextBlock Margin="4" Text="{Binding Header}"/>
                                </ContentPresenter.Content>
                            </ContentPresenter>
                        </Border>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
