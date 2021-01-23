    public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
    {
        if( sourceType == typeof(string) )
            return true;
        else 
            return base.CanConvertFrom(context, sourceType);
    }
