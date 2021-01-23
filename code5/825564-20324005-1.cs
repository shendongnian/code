    foreach (String _application in _applications)
                {
    
                    TabPage _page = null;
    
                    Type[] _atypes = new Type[] { typeof(Panel) };
                    Object[] _avalues = new Object[] { _container };
                    ConstructorInfo _ctor = Type.GetType("SFM." + _application).GetConstructor(_atypes);
                    Object _control = _ctor.Invoke(_avalues);
                    
                    if (_control != null)
                    {
                        _page = new TabPage();
                        _page.Text = _application;
                        _page.Controls.Add((Control)_control);
                    }
    
                    if (_page != null)
                    {
    
                        tapplications.TabPages.Add(_page);
                        m_list.Add(_count, _page);
                        _count++;
    
                    }
    
                }
