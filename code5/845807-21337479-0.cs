    Bundle bndl = BundleTable.Bundles.GetBundleFor("~/Content/css");
                if (bndl != null)
                {
                    BundleTable.Bundles.Remove(bndl);
                }
    
                Bundle bndl2 = new Bundle("~/Content/css");
                bndl2.Include("~/Content/site.css", "~/Content/secondStyles.css", ... );
                BundleTable.Bundles.Add(bndl2);
