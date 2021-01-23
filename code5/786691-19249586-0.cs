        public bool CheckProperty(string property_name)
        {
            try
            {
                Eval(property_name);
            }
            catch { return false; }
            return true;
           
        }
