    <Button Content="Test">
       <Button.Style>
         <Style TargetType="Button">
           <Setter Property="Visibility" Value="Collapsed"/>
           <Style.Triggers>
             <DataTrigger Value="True">
               <DataTrigger.Binding>
                 <MultiBinding
                      Converter="{StaticResource IsLastItemInContainerConverter}">
                    <Binding Path="."
                             RelativeSource="{RelativeSource Mode=FindAncestor, 
                                               AncestorType=ListViewItem}"/>
                    <Binding Path="DataContext.SourceCollection.Count"
                             RelativeSource="{RelativeSource Mode=FindAncestor, 
                                                        AncestorType=ListView}"/>
                 </MultiBinding>
               </DataTrigger.Binding>
               <Setter Property="Visibility" Value="Visible"/>
             </DataTrigger>
           </Style.Triggers>
         </Style>
       </Button.Style>
    </Button>
