        #region Private Fields
        private readonly ObservableCollection<Country> _countries = new ObservableCollection<Country>();        
        private readonly List<string> _stateTotalAttributes = new List<string>();        
        #endregion
        public ViewModel()
        {
            FillData();
            var stateAttributes = new string[] {"Population", "Unemployment Rate", "Capital", "Governor", "TimeZone", "Area"};
            foreach (var stateAttribute in stateAttributes)
                _stateTotalAttributes.Add(stateAttribute);                            
        }
        public ObservableCollection<Country> Countries
        {
            get { return this._countries; }
        }
        public FieldLayout GridFieldLayout { get; set; }
        /// <summary>
        /// Country and the states are populated
        /// </summary>
        private void FillData()
        {
            var country = new Country();
            country.States = new ObservableCollection<State>();            
            country.Name = "USA";            
            
            var xdoc = XDocument.Load("states_data.xml");
            foreach (var state in xdoc.Descendants("states").Descendants())
            {
                var newState = new State();
                newState.StateName = state.Attributes("name").FirstOrDefault().Value;
                newState["Unemployment Rate"] = state.Attributes("unemployment-rate").FirstOrDefault().Value;
                newState["Capital"] = state.Attributes("capital").FirstOrDefault().Value;
                newState["Governor"] = state.Attributes("governor").FirstOrDefault().Value;
                newState["Area"] = state.Attributes("area").FirstOrDefault().Value;
                newState["TimeZone"] = state.Attributes("timezone").FirstOrDefault().Value;
                newState["Population"] = state.Attributes("population").FirstOrDefault().Value;
                country.States.Add(newState);
            }
            
            _countries.Add(country);
        }
        public void AddStateAttributes()
        {
            GridFieldLayout.Fields.BeginUpdate();
            // Remove the current columns (except for StateName)
            var removableFields = GridFieldLayout.Fields.Where(f => f.Name != "StateName");
            removableFields.ToList().ForEach(field => GridFieldLayout.Fields.Remove(field));
                        
            // Figure out what state attributes to add
            var random = new Random(DateTime.Now.Millisecond);
            var numCols = random.Next(1, 6);
            var colsToAdd = GetStateAttributes(numCols, random);
            // Finally add the new ones'
            foreach (var col in colsToAdd)
            {
                var field = new UnboundField();
                field.Name = col;
                field.Binding = new Binding()
                {
                    Mode = BindingMode.TwoWay,
                    Path = new PropertyPath(string.Format("[{0}]",  col)),
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                };
                GridFieldLayout.Fields.Add(field);
            }
            GridFieldLayout.Fields.EndUpdate();
        }
        private List<string> GetStateAttributes(int numCols, Random random)
        {            
            List<string> colsToAdd = new List<string>();
            for( int i = 0; i < numCols; i++)
            {
                int idx = random.Next(1, 6) - 1;
                if(colsToAdd.Contains(_stateTotalAttributes[idx]) == false)
                {
                    colsToAdd.Add(_stateTotalAttributes[idx]);
                }
            }
            return colsToAdd;
        }
    }
