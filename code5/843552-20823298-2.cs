    <Image Tag="{Binding ElementName=lbl02scanning,Path=Content}">
       <Image.ToolTip>
          <ToolTip>
              <TextBlock Text="{Binding RelativeSource={RelativeSource 
                                        Mode=FindAncestor, AncestorType=ToolTip},
                                        Path=PlacementTarget.Tag,
                                        ConverterParameter=255,
                               Converter={StaticResource FormatterFOrCoilToolTip}}"/>
           </ToolTip>
       </Image.ToolTip>
    </Image>
