     <Button local:Color.CustomBackground="CadetBlue">
                <Button.Template>
                    <ControlTemplate TargetType="Button">
                        <ContentPresenter>
                            <ContentPresenter.ContentTemplate>
                                <ItemContainerTemplate>
                                    <Border Width="50" Height="{Binding RelativeSource={RelativeSource Self}, Path=Width}"
                                            Background="{Binding RelativeSource={RelativeSource AncestorType=Button}, Path=(local:Color.CustomBackground)}">
                                       
                                    </Border>
                                </ItemContainerTemplate>
                            </ContentPresenter.ContentTemplate>
                        </ContentPresenter>
                    </ControlTemplate>
                </Button.Template>
            </Button>
