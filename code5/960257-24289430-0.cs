        public Object GetElement(string name)
        {
            Object element = null;
            foreach (var item in this)
            {
                if (item.ToString() == name)
                {
                    element = item;
                    break;
                }
            }
            return element;
        }
