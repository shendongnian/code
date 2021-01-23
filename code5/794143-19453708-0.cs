                   Background="{Binding 
                            RelativeSource={RelativeSource Self},
                            Path=DataContext.IsDirty, 
                            UpdateSourceTrigger=PropertyChanged, 
                            Converter={StaticResource IsDirtyConverter}}"
