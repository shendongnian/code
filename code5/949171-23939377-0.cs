    public void EditBinding(int id, SiteBinding siteBinding, string newKeyName)
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    if (serverManager.Sites == null)
                        return;
    
                    for (int i = 0; i < serverManager.Sites.Count; i++)
                    {
                        if (serverManager.Sites[i].Id == id)
                        {
                            Microsoft.Web.Administration.BindingCollection bindingCollection = serverManager.Sites[i].Bindings;
    
                            // se elimina el binding
                            Microsoft.Web.Administration.Binding bindingTmp = null;
                            for (int j = 0; j < bindingCollection.Count; j++)
                            {
                                if (bindingCollection[j].Host == bindingNameBase[newKeyName].ToString())
                                {
                                    bindingTmp = bindingCollection[j];                                
                                    break;
                                }
                            }
    
                            if (bindingTmp != null)
                            {
                                bindingCollection.Remove(bindingTmp);
    
                                //se crea de nuevo
                                Microsoft.Web.Administration.Binding binding = serverManager.Sites[i].Bindings.CreateElement("binding");
                                binding["protocol"] = siteBinding.Protocol;
                                binding["bindingInformation"] = string.Format(@"{0}:{1}:{2}", siteBinding.IPAddress, siteBinding.Port.ToString(), siteBinding.HostName);
    
                                bool existe = false;
                                for (int j = 0; j < bindingCollection.Count; j++)
                                {
                                    if (bindingCollection[j].Host == siteBinding.HostName)
                                    {
                                        existe = true;
                                        break;
                                    }
                                }
    
                                if (existe == false)
                                {
                                    bindingCollection.Add(binding);
                                    serverManager.CommitChanges();
    
                                    bindingNameBase[newKeyName] = siteBinding.HostName;
                                }
                            }                        
                        }
                    }
