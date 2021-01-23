        private ParameterValue[] _ParamDependenciesValues = new ParameterValue[0];
       protected ItemParameter[] GetReportParameterDependencies()
        {
            ItemParameter[] Parameters = _Rs.GetItemParameters(_ThisReportPath, null, true, _ParamDependenciesValues, null);
           
            if (Parameters.Length > 0)
            {
                foreach (ItemParameter p in Parameters)
                {
                    if (p.Dependencies != null)
                    {
                        foreach (var d in p.Dependencies)
                        {
                            if (!_Dependencies.Contains(d))
                            {
                                _Dependencies.Add(d, null);
                            }
                        }
                    }
                }
            }
            return Parameters;
        }
