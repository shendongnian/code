    public DateTime? GetSafeDateTimeValue(object datetimeValue)
            {
                if (datetimeValue == null || datetimeValue == DBNull.Value)
                    return null;
                else
                {
                    try
                    {
                        if (!DateTime.TryParse(datetimeValue.ToString(), out tempDateTimeValue))
                            return null;
                        else
                            return tempDateTimeValue;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
