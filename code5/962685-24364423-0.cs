    xmlns:toolkit="clr-namespace:Microsoft.Phone.Controls;assembly=Microsoft.Phone.Controls.Toolkit"
    <toolkit:GestureService.GestureListener>
         <toolkit:GestureListener Hold="GroupItem_Hold"/>
     </toolkit:GestureService.GestureListener>
    <toolkit:ContextMenuService.ContextMenu>
                                    <toolkit:ContextMenu>
                                        
                                        <toolkit:MenuItem Header="Remove Group" Click="removeGroup"/>
                                    </toolkit:ContextMenu>
                                </toolkit:ContextMenuService.ContextMenu>
