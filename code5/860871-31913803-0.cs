            try
            {
                SqlSyncScopeDeprovisioning obj1 = new SqlSyncScopeDeprovisioning(clientConn) { CommandTimeout = 60 * 30 };
                obj1.DeprovisionScope(scopeName);
            }
            catch { }
            // get the description of ProductsScope from the SyncDB server database
            DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(scopeName, serverConnection);
            
            SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);
            if (!clientProvision.ScopeExists(scopeName))
            {
                //apply the scope definition
                clientProvision.Apply();
            }
