        protected void SetParamValues(ItemParameter[] Params)
        {
            foreach (ItemParameter Rp in Params)
            {
                if (Rp.Dependencies != null)
                {
                    foreach (var d in Rp.Dependencies)
                    {
                        var MyParamValue = _ParamDependenciesValues.FirstOrDefault(c => c.Name == d);
                        if (MyParamValue == null)
                        {
                            Array.Resize(ref _ParamDependenciesValues, _ParamDependenciesValues.Count() + 1);
                            var MyNewParamValue = new ParameterValue {Name = d};
                            _ParamDependenciesValues[_ParamDependenciesValues.Length - 1] = MyNewParamValue;
                            MyParamValue = _ParamDependenciesValues.FirstOrDefault(c => c.Name == d);
                        }
                        if (_Dependencies.Contains(d))
                        {
                            switch (d)
                            {
                                case "CompanyId":
                                    _Dependencies[d] = _MyCompanyId.ToString();
                                    break;
                                case "SecurityId":
                                    _Dependencies[d] = SessionContext.Current.Member.SecurityUniqueID.ToString();
                                    break;
                            }
                            if (MyParamValue != null && _Dependencies[d] != null)
                                MyParamValue.Value = _Dependencies[d].ToString();
                        }
                    }
                }
                else
                {
                    //if (_Dependencies.Contains())
                }
            }
        }
