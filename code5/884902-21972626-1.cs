    private FrameworkElement GenerateChildrenEditorElement( PropertyItem propertyItem )
    {
      FrameworkElement editorElement = null;
      DescriptorPropertyDefinitionBase pd = propertyItem.DescriptorDefinition;
      object definitionKey = null;
      Type definitionKeyAsType = definitionKey as Type;
    
      ITypeEditor editor = pd.CreateAttributeEditor();
      if( editor != null )
    	editorElement = editor.ResolveEditor( propertyItem );
    
    
      if( editorElement == null && definitionKey == null )
    	editorElement = this.GenerateCustomEditingElement( propertyItem.PropertyDescriptor.Name, propertyItem );
    
      if( editorElement == null && definitionKeyAsType == null )
    	editorElement = this.GenerateCustomEditingElement( propertyItem.PropertyType, propertyItem );
    
      if( editorElement == null )
      {
    	if( pd.IsReadOnly )
    	  editor = new TextBlockEditor();
    
    	// Fallback: Use a default type editor.
    	if( editor == null )
    	{
    	  editor = ( definitionKeyAsType != null )
    	  ? PropertyGridUtilities.CreateDefaultEditor( definitionKeyAsType, null )
    	  : pd.CreateDefaultEditor();         
    	}
    
    	Debug.Assert( editor != null );
    
    	editorElement = editor.ResolveEditor( propertyItem );
    
    	  if(editorElement is IntegerUpDown)
    	  {
    		  var rangeAttribute = PropertyGridUtilities.GetAttribute<RangeAttribute>(propertyItem.DescriptorDefinition.PropertyDescriptor);
    		  if (rangeAttribute != null)
    		  {
    			  IntegerUpDown integerEditor = editorElement as IntegerUpDown;
    			  integerEditor.Minimum = rangeAttribute.Min;
    			  integerEditor.Maximum = rangeAttribute.Max;
    		  }
    	  }
      }
    
      return editorElement;
    }
