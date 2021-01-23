        public static DataGridColumn CreateAppropreateColumn(string path, PropertyInfo info, string header, IRepository repository)
        {
            var criteria = new Dictionary<Type, Func<string, PropertyInfo, string, IRepository, DataGridColumn>>();
            
            criteria.Add(typeof(DbComboBoxAttribute), CreateComboBoxColumn);
            criteria.Add(typeof(DescribedByteEnumComboBoxAttribute)), CreateEnumComboBoxColumn);
            criteria.Add(typeof(DropDownLazyLoadingDataGridAttribute), CreateDataGridDropDownLazyLoadingDataGridColumn);
            // add more here - in the order you desired...            
            // loop through and return out if there is a matched one
            foreach (Type t in criteria.Keys)
            {
                if (info.GetCustomAttributes(t, true).Any())
                {
                    return criteria[t].Invoke(path, info, header, repository);
                }
            }
            
            // Default Return here:
            return CreateTextBoxColumn(path, info, header);
        }
