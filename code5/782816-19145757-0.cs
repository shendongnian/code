        public string GetRangeName(range As Range)
        {
            try
            {
                var name = range.Name;
                if (name == null) return null; // Won't happen in the current version of Excel, but who knows for a future version
                return name.Name;
            }
            catch(COMException)
            {
                return null;
            }
        }
