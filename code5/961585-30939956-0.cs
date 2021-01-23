    Reset = 0,//     Much of the list has changed. Any listening controls should refresh all their data from the list.
    ItemAdded = 1,//     An item added to the list
    ItemDeleted = 2,//     An item deleted from the list.
    ItemMoved = 3,//     An item moved within the list.
    ItemChanged = 4,//     An item changed in the list.
    PropertyDescriptorAdded = 5,//     A System.ComponentModel.PropertyDescriptor was added, which changed the schema.
    PropertyDescriptorDeleted = 6,//     A System.ComponentModel.PropertyDescriptor was deleted, which changed the schema.
    PropertyDescriptorChanged = 7//     A System.ComponentModel.PropertyDescriptor was changed, which changed the schema.
