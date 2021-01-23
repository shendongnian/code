        public ConfigWrapper(object obj)
        {
            _original = obj;
            // copy all properites
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(obj))
            {
                // filter hideable attributes
                bool add = true;
                foreach (Attribute attribute in property.Attributes)
                    if (attribute is Common.IHide && (attribute as Common.IHide).Hide)
                    {
                        add = false;
                        break;
                    }
                ////////////////////////
                // filter configurable via hide property properties
                var hide = obj.GetType().GetProperty(property.Name + "Hide", BindingFlags.Instance | BindingFlags.NonPublic);
                if (hide != null && (bool)hide.GetValue(obj, null))
                    add = false;
                ///////////////////////
                // add
                if (add)
                    _collection.Add(new ConfigDescriptor(property));
            }
        }
