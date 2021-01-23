    MyEntity entity = new MyEntity();
    MyEntitySet.Attach(entity);
    ((IEditableObject)entity).BeginEdit();
    // edit the properties of the entity;
    ((IEditableObject)entity).EndEdit();
