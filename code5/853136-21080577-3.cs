    SiteMapNode childNode1 = new SiteMapNode(this, 
    "<http://support.microsoft.com>", "<http://support.microsoft.com>", "Support");
    
    nodeColl.Add(childNode);
    
    SiteMapNodeCollection test = new SiteMapNodeCollection();
    test.Add(childNode1);
    childNode.ChildNodes = test;
    
    return nodeColl;
    }
    else
    return base.GetChildNodes(pNode);
    }
    else
    return new SiteMapNodeCollection();
    }
    }
    }
