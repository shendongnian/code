       [TestMethod]
        public void EFToolsTest() {
        //  http://msdn.microsoft.com/en-us/library/system.data.metadata.edm.dataspace(v=vs.110).aspx
            var context = new YourContext(); // DbContext type
            ObjectContext objContext = ((IObjectContextAdapter)context).ObjectContext;
            MetadataWorkspace workspace = objContext.MetadataWorkspace;
 
            var xyz = workspace.GetItems<EntityType>(DataSpace.SSpace);
            foreach (var ET in xyz) {
                foreach (var sp in ET.Properties) {
                    Debug.WriteLine(sp.Name + ":" + sp.MaxLength);// just as an example
                    
                    }
                }
            }
