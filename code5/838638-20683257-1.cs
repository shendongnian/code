    Public Class Item
         Public ID as integer // id of item (apple=1, hammer=2)
         Public Position as vector2 // position in your inventory
         Public Equiped as boolean = false;
    End Class
    
    Public Class Items
         Inherit List of(Item)
    
         Sub Add(id)
             dim Item as new Item
             Item.ID = id
             // find first free slot and apply position to Item.Position
             me.add(Item)
         End Sub
         Sub Remove(id)
             me.removeAll(function(c) c.id = id)
         End Sub
         Sub Relocate(id, newPostion)
             // example of looping
             For Each Item as Item in Me
                 If Item.ID = id Then
                     Item.Position = newPosition
                 End If
             Next
         End Sub
         Sub Equip(id)
             Dim Item as Item = me.find(function(c) c.id=id)
             Item.Equiped = true;
         End Sub
    
    End Class
