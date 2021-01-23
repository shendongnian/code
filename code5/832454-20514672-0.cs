        public bool itemchecked
        {
            get
            { 
                var checkedBoxes = new List<CheckBox>();
        
                foreach(var item in AllCheckBoxes)
                {
                    if(item.Checked)
                    {
                       checkedBoxes.Add(item);
                    }
                }
        
                return checkedBoxes;
            }
        }
