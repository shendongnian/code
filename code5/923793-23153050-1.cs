    class RowPropertyDescriptor : PropertyDescriptor
    {
        private int index;
        public RowPropertyDescriptor(string name, int index)
            : base(name, null)
        {
            this.index = index;
        }
        #region PropertyDescriptor
        public override string DisplayName { get { return Name; } }
        public override Type ComponentType { get { return typeof(double); } }
        public override bool IsReadOnly { get { return false; } }
        public override Type PropertyType { get { return typeof(double); } }
        public override object GetValue(object component)
        {
            return ((Row)component)[index];
        }
        public override void SetValue(object component, object value)
        {
            ((Row)component)[index] = (double)value;
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override void ResetValue(object component)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        #endregion
    }
    class Row : DynamicObject
    {
        private Table table;
        private int row;
        public Row(Table namedArraysView, int row)
        {
            this.table = namedArraysView;
            this.row = row;
        }
        public double this[int col]
        {
            get { return table.RawData[col].Data[row]; }
            set { table.RawData[col].Data[row] = value; }
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            int idx;
            bool found = table.PropertiesIndex.TryGetValue(binder.Name, out idx);
            if (found)
            {
                try
                {
                    this[idx] = Convert.ToDouble(value);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return base.TrySetMember(binder, value);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            int idx;
            bool found = table.PropertiesIndex.TryGetValue(binder.Name, out idx);
            if (found)
            {
                result = this[idx];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return table.PropertyNames;
        }
    }
    class Table : BindingList<Row>, ITypedList
    {
        public ObservableCollection<INamedArray> RawData { get; private set; }
        internal List<string> PropertyNames { get; private set; }
        internal Dictionary<string, int> PropertiesIndex { get; private set; }
        public Table(ObservableCollection<INamedArray> headeredArrays)
        {
            bind(headeredArrays);
            headeredArrays.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => { bind(headeredArrays); };
        }
        private void bind(ObservableCollection<INamedArray> headeredArrays)
        {
            Clear();
            if (headeredArrays == null)
            {
                RawData = null;
                PropertyNames = null;
                PropertiesIndex = null;
                return;
            }
            RawData = headeredArrays;
            PropertyNames = RawData.Select(d => d.Name).ToList();
            PropertiesIndex = new Dictionary<string, int>();
            for (int i = 0; i < RawData.Count; i++)
                PropertiesIndex.Add(RawData[i].Name, i);
            int nRows = headeredArrays[0].Data.Count;
            for (int i = 0; i < nRows; i++)
                Add(new Row(this, i));
        }
        #region ITypedList
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            var dynamicDescriptors = new List<PropertyDescriptor>();
            if (this[0].GetDynamicMemberNames() == null) return new PropertyDescriptorCollection(new PropertyDescriptor[] { });
            var memberNames = this[0].GetDynamicMemberNames().ToArray();
            for (int i = 0; i < memberNames.Length; i++)
                dynamicDescriptors.Add(new RowPropertyDescriptor(memberNames[i], i));
            return new PropertyDescriptorCollection(dynamicDescriptors.ToArray());
        }
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return null;
        }
        #endregion
    }
