                <Style.Triggers>
                <Trigger Property="IsChecked" Value="true">
                    <Setter Property="Command" Value="{Binding ElementName=this, Path=DataContext.ItemCheckedCommand}"></Setter>
                </Trigger>
                <Trigger Property="IsChecked" Value="false">
                    <Setter Property="Command" Value="{Binding ElementName=this, Path=DataContext.ItemCheckedCommand}"></Setter>
                </Trigger>
            </Style.Triggers>
