        public bool ShowPropertyPage(object videFilter, string nameOfFiler, Controler owner )
        {
            ISpecifyPropertyPages specifyPropertyPages = null;
            DsCAUUID cauuid = new DsCAUUID();
            bool hasPropertyPage = false;
            // Determine if the object supports the interface
            // and has at least 1 property page
            try
            {
                specifyPropertyPages = videFilter as ISpecifyPropertyPages;
                if (specifyPropertyPages != null)
                {
                    int hr = specifyPropertyPages.GetPages(out cauuid);
                    if ((hr != 0) || (cauuid.cElems <= 0))
                        specifyPropertyPages = null;
                }
            }
            finally
            {
                if (cauuid.pElems != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(cauuid.pElems);
            }
            // Add the page to the internal collection
            if (specifyPropertyPages != null)
            {
                DirectShowPropertyPage p = new DirectShowPropertyPage(nameOfFiler, specifyPropertyPages);
                p.Show(owner);
                hasPropertyPage = true;
            }
            return (hasPropertyPage);
        }
