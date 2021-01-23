    string fetchContentString(object o)
            {
                if (o == null)
                {
                    return null;
                }
    
                if(o is string)
                {
                    return o.ToString();
                }
    
                if(o is ContentControl)
                {
                    var cc = o as ContentControl;
    
                    if (cc.HasContent)
                    {
                        return fetchContentString(cc.Content);
                    }
                    else
                    {
                        return null;
                    }
    
                }
    
                if(o is Panel)
                {
                    var p = o as Panel;
                    if (p.Children != null)
                    {
                        if (p.Children.Count > 0)
                        {
                            if(p.Children[0] is ContentControl)
                            {
                                return fetchContentString((p.Children[0] as ContentControl).Content);
                            }
                            else
                            {
                                return fetchContentString(p.Children[0]);
                            }
                        }
                    }
                }
    
                return null;
            }
