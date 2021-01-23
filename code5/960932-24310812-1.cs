    public string Resolve(MemberInfo info)
    		{
    			if (info == null)
    				return null;
    
    			var name = info.Name;
    			**var resolvedName = name.ToCamelCase();**
    			var att = ElasticAttributes.Property(info);
    			if (att != null && !att.Name.IsNullOrEmpty())
    				resolvedName = att.Name;
    
    			return resolvedName;
    		}
