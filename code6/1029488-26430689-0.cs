    <Image Source="...">                        
       <Image.Style>
           <Style TargetType="{x:Type Image}">
               <Setter Property="Effect">
                   <Setter.Value>
                       <BlurEffect Radius="8"/>
                   </Setter.Value>
               </Setter>
               <Style.Triggers>
                   <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TabItem}}, Path=IsSelected}" Value="True">
                       <Setter Property="Effect">
                           <Setter.Value>
                               <BlurEffect Radius="2"/>
                           </Setter.Value>
                       </Setter>
                   </DataTrigger>
               </Style.Triggers>
           </Style>
       </Image.Style>
    </Image>
