      [TestMethod]
        public void EFToolsTest() {
       
            var context = new BosMasterDbContext("MYDBCONTEXT");
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
 
            var xyz = workspace.GetItems<EntityType>(DataSpace.SSpace);
            foreach (var ET in xyz) {
                foreach (var sp in ET.Properties) {
                    Debug.WriteLine(sp.Name + ":" + sp.MaxLength);
                    
                    }
                }
            }
 
