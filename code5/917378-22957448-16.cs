    private static bool IsScalarPropertyModified(this ObjectContext context, string scalarPropertyName, IEntityWithKey entityContainer, out ObjectStateEntry containerStateEntry)
    				{
    					bool isModified = false;
    					containerStateEntry = context.ObjectStateManager.GetObjectStateEntry(entityContainer.EntityKey);
    					IEnumerable<string> modifiedProperties = containerStateEntry.GetModifiedProperties();
    
    					string changedProperty = modifiedProperties.FirstOrDefault(element => (element == scalarPropertyName));
    					isModified = (null != changedProperty);
    
                        if (isModified) 
                        {
                            object originalValue = containerStateEntry.OriginalValues[changedProperty];
                            object currentValue = containerStateEntry.CurrentValues[changedProperty];
                            //sometimes property can be treated as changed even though you set the same value it had before
                            isModified = !object.Equals(originalValue, currentValue);
                        }
    
    					return isModified;
    				}
