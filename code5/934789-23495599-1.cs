    if (_toDelete.IsNotNull())
            {
                _stations.Remove(_toDelete);
    
                var station = 1;
    
                foreach (var item in _stations)
                {
                    item.ID = station++;
                }
    
                stationEntityBindingSource.DataSource = null;
                gridStations.Update();
                stationEntityBindingSource.DataSource = _stations;
                
                //add this line
                gridStations.DataSource = null;
                gridStations.DataSource = stationEntityBindingSource;
    
                _toDelete = null;
            }
