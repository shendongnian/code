    public class ReportService
    {
        EntityName dbContext = new EntityName();
        
        List<string> tabloIsimleri = new List<string>();
        List<string> tabloListesi = new List<string>();
        List<string> iliskiliOlanlar = new List<string>();
        Dictionary<string, List<string>> agacGosterim = new Dictionary<string, List<string>>();
        public void Test()
        {
            try
            {
                tabloListesi = Tablolar();
                string tutmac;
                foreach (var t in tabloListesi)
                {
                    tutmac = string.Format("ProjectName.DataService.{0}", t);
                    var tip = Type.GetType(tutmac, true);
                    foreach (_PropertyInfo p in tip.GetProperties())
                    {
                        var propName = p.PropertyType.FullName;
                        if (propName.Contains("ProjectName.DataService"))
                        {
                            string[] test = p.Name.Split(' ');
                            int a = test.Count();
                            var son = test[a - 1];
                            if (!iliskiliOlanlar.Contains(son))
                            {
                                iliskiliOlanlar.Add(son);
                            }
                        }
                    }
                    agacGosterim.Add(t, iliskiliOlanlar);
                    iliskiliOlanlar = new List<string>();
                }
            }
            catch (Exception)
            {
            }
        }
        public List<string> Tablolar()
        {
            using (var context = new EntityName())
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                var entityProps = (from s in storageMetadata where s.BuiltInTypeKind == BuiltInTypeKind.EntityType select s as EntityType);
                foreach (var item in entityProps)
                {
                    string[] ayir = item.FullName.Split('.');
                    int a = ayir.Count() - 1;
                    if (!tabloIsimleri.Contains(ayir[a]))
                    {
                        tabloIsimleri.Add(ayir[a]);
                    }
                }
                return tabloIsimleri;
            }
        }
    }
