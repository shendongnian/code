     int _total = 0;
                    foreach (DataRow _dr in dt.Rows) // Looping Rows
                    {
                        int _value = 0;
                        foreach (var _column in _dr.ItemArray) // Looping Columns
                        {
                            if (_column.ToString() != "")
                            {
                              //if column value is not equal to blank , keep assign it to _value 
                               _value = Int32.Parse(_column.ToString());
                               
                            }
                            else
                            {
                             //if column value is equal to blank , sum-up the _total with _value and break column looping and go to next row
                                _total += _value;
                                break;
                            }
                        }
                    }
