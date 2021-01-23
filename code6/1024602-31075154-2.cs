                        ServerManager serverManager = new ServerManager();
                        var site = serverManager.Sites["Default Web Site"];
                        site.Bindings.Add("*:443:TestClient", certificate[0].GetCertHash(), "MY");
                        //  site.Bindings.Add("*:443:TestClient", "https");
                        serverManager.CommitChanges();
