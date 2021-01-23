    public class MyImage{
      public int Id{get;set;}
    }
    ....<TabControl.ItemContainerStyle>
                <Style TargetType="TabItem">
                    <Setter Property="Header" Value="{Binding Path=Id}"/>
                </Style>
            </TabControl.ItemContainerStyle>
