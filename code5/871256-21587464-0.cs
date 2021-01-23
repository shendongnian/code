    var _rowlist = table.AsEnumerable().OrderBy(x => x.Field<Int32>("COL1")).ThenBy(x => x.Field<string>("COL2")).ThenBy(x => x.Field<string>("COL3")).ThenBy(x => x.Field<string>("COL4")).ToList();
                DataTable _newtable = table.Clone();
                string oldrowid = "";
                foreach (DataRow _indrow in _rowlist)
                {
                    if (!oldrowid.Equals(_indrow["COL1"].ToString()))
                    {
                        oldrowid = _indrow["COL1"].ToString();
                        DataRow _newrow = _newtable.NewRow();
                        _newrow["COL1"] = _indrow["COL1"].ToString();
                        _newrow["COL2"] = _indrow["COL2"].ToString();
                        _newrow["COL3"] = _indrow["COL3"].ToString();
                        _newrow["COL4"] = _indrow["COL4"].ToString();
                        _newrow["COL5"] = _indrow["COL5"].ToString();
                        _newtable.Rows.Add(_newrow);
                    }
                    else
                    {
                        Int32 _id = Int32.Parse(_indrow["COL1"].ToString());
                        DataRow _row = _newtable.AsEnumerable().Where(a => a.Field<Int32>("COL1") == _id).SingleOrDefault();
                        int Index = _newtable.Rows.IndexOf(_row);
                        _row["COL5"] += "," + _indrow["COL5"].ToString();
                    }
                }
    
    //_newtable contains what you want
